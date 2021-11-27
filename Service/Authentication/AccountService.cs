using MeroBolee.Dto;
using MeroBolee.Infrastructure;
using MeroBolee.Model;
using MeroBolee.Repository;
using MeroBolee.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MeroBolee.Service
{


    /// <summary>
    /// Interface for User Authentication
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="model"></param>
        /// <param name="companyRegisteredAs"></param>
        /// <param name="basePath"></param>
        /// <param name="defaultPicture"></param>
        /// <returns></returns>
        Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model, CompanyTypeEnum companyRegisteredAs, string basePath, string defaultPicture);

    }

    /// <summary>
    /// Service to authenticate user
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IUploadFile uploadFile;
        private readonly JWTSettings jwtsetting;
        private readonly ICryptoService cryptoService;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="cryptoService"></param>
        /// <param name="accountRepository"></param>
        /// <param name="jwtSettings"></param>
        /// <param name="uploadFile"></param>
        public AccountService(ICryptoService cryptoService, IAccountRepository accountRepository, IOptions<JWTSettings> jwtSettings, IUploadFile uploadFile)
        {
            this.cryptoService = cryptoService;
            this.accountRepository = accountRepository;
            this.uploadFile = uploadFile;
            jwtsetting = jwtSettings.Value;
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="model"></param>
        /// <param name="companyRegisteredAs"></param>
        /// <param name="basePath"></param>
        /// <param name="defaultPicture"></param>
        /// <returns></returns>
        public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model, CompanyTypeEnum companyRegisteredAs, string basePath, string defaultPicture)
        {
            try
            {
                model.Password = cryptoService.Encrypt(model.Password);
                AuthenticateResponse account = accountRepository.AuthenticateAsync(model, companyRegisteredAs);

                if (account != null)
                {
                    if(!string.IsNullOrEmpty(account.ProfilePicture))
                    {
                        bool fileExists = await uploadFile.FileExists(account.ProfilePicture);
                        if(!fileExists)
                        {
                            account.ProfilePicture = defaultPicture;
                        }
                        else
                        {
                            account.ProfilePicture = $"{basePath}{account.ProfilePicture.Replace("\\", "/")}";
                        }
                    }
                    else
                    {
                        account.ProfilePicture = defaultPicture;
                    }
                    DateTime expiryTime;
                    // authentication successful so generate jwt and refresh tokens
                    var jwtToken = generateToken(account, out expiryTime);// generateJwtToken(account);
                    //var refreshToken = generateRefreshToken(ipAddress);
                    //account.RefreshTokens.Add(refreshToken);

                    // remove old refresh tokens from account
                    //removeOldRefreshTokens(account);

                    // save changes to db
                    //_context.Update(account);
                    //_context.SaveChanges();
                    account.TokenExpiryTime = expiryTime;
                    account.JwtToken = jwtToken;
                    //account.RefreshToken = refreshToken.Token;
                }
                return account;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string generateToken(AuthenticateResponse acc, out DateTime tokenExpiresAt)
        {
            string info = JsonConvert.SerializeObject(acc);
            var claims = new List<Claim>();
            claims.Add(new Claim("id", acc.Id.ToString()));
            claims.Add(new Claim("user", info));           
            claims.Add(new Claim(ClaimTypes.Role, acc.Role));
            claims.Add(new Claim(ClaimTypes.Name, $"{acc.FirstName} {acc.MiddleName} {acc.LastName}"));
            claims.Add(new Claim(ClaimTypes.Email, acc.Email));

            var token = JwtHelper.GetJwtToken(jwtsetting, acc.Email, out tokenExpiresAt, claims.ToArray());
            string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenStr;

        }


        [Obsolete]
        private string generateJwtToken(AuthenticateResponse account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtsetting.Secret);
            string info = JsonConvert.SerializeObject(account);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = jwtsetting.Issuer,
                Issuer = jwtsetting.Issuer,
                Subject = new ClaimsIdentity(new[] {
                    new Claim("id", account.Id.ToString()) ,
                    new Claim("user", info),
                    new Claim("UserStatus", account.UserStatusId.ToString()),
                    new Claim(ClaimTypes.Role, account.Role),
                    new Claim(ClaimTypes.NameIdentifier, $"{account.FirstName} {account.LastName}"),
                    new Claim(ClaimTypes.Name, $"{account.FirstName} {account.MiddleName} {account.LastName}"),
                    new Claim(ClaimTypes.Email, account.Email)
                }),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(jwtsetting.TokenExpiryInMinute),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        //private RefreshToken generateRefreshToken(string ipAddress)
        //{
        //    return new RefreshToken
        //    {
        //        Token = randomTokenString(),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        Created = DateTime.UtcNow,
        //        CreatedByIp = ipAddress
        //    };
        //}

        //private void removeOldRefreshTokens(AuthenticateResponse account)
        //{
        //    account.RefreshTokens.RemoveAll(x =>
        //        !x.IsActive &&
        //        x.Created.AddDays(_appSettings.RefreshTokenTTL) <= DateTime.UtcNow);
        //}

        private static string randomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
    }

    public class JwtHelper
    {
        public static JwtSecurityToken GetJwtToken(JWTSettings jWTSettings, string username, out DateTime tokenExpiryDate, Claim[] additionalClaims = null)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,username),
                // this guarantees the token is unique
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            if (additionalClaims is object)
            {
                var claimList = new List<Claim>(claims);
                claimList.AddRange(additionalClaims);
                claims = claimList.ToArray();
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jWTSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            tokenExpiryDate = DateTime.UtcNow.AddMinutes(jWTSettings.TokenExpiryInMinute);
            return new JwtSecurityToken(
                issuer: jWTSettings.Issuer,
                audience: jWTSettings.Issuer,
                expires: tokenExpiryDate,
                claims: claims,
                signingCredentials: creds
            );

        }
    }
}
