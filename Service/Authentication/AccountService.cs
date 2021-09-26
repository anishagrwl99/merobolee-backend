using MeroBolee.Dto;
using MeroBolee.Model;
using MeroBolee.Repository;
using MeroBolee.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
        AuthenticateResponse AuthenticateAsync(AuthenticateRequest model);
       
    }

    /// <summary>
    /// Service to authenticate user
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly JWTSettings jwtsetting;
        private readonly ICryptoService cryptoService;

        public AccountService(ICryptoService cryptoService, IAccountRepository accountRepository, IOptions<JWTSettings> jwtSettings)
        {
            this.cryptoService = cryptoService;
            this.accountRepository = accountRepository;
            jwtsetting = jwtSettings.Value;
        }

        public  AuthenticateResponse AuthenticateAsync(AuthenticateRequest model)
        {
            try
            {
                model.Password = cryptoService.Encrypt(model.Password);
                AuthenticateResponse account = accountRepository.AuthenticateAsync(model);

                if (account != null)
                {

                    // authentication successful so generate jwt and refresh tokens
                    var jwtToken = generateJwtToken(account);
                    //var refreshToken = generateRefreshToken(ipAddress);
                    //account.RefreshTokens.Add(refreshToken);

                    // remove old refresh tokens from account
                    //removeOldRefreshTokens(account);

                    // save changes to db
                    //_context.Update(account);
                    //_context.SaveChanges();

                    account.JwtToken = jwtToken;
                    //account.RefreshToken = refreshToken.Token;
                }
                return account;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        private string generateJwtToken(AuthenticateResponse account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtsetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = jwtsetting.Issuer,
                Issuer = jwtsetting.Issuer,
                Subject = new ClaimsIdentity(new[] { new Claim("id", account.Id.ToString()) }),
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

        private string randomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
    }
}
