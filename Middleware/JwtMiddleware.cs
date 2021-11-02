using MeroBolee.Dto;
using MeroBolee.Model;
using MeroBolee.Settings;
using MeroBolee.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MeroBolee.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache cache;
        private readonly JWTSettings _jwtSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<JWTSettings> jwtSettings, IMemoryCache cache)
        {
            _next = next;
            this.cache = cache;
            _jwtSettings = jwtSettings.Value;
        }

        /// <summary>
        /// Check the Authorization header for user identification
        /// </summary>
        /// <param name="context">Context in which authorization is invoked</param>
        /// <param name="dataContext">Database context for user lookup</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, MeroBoleeDbContext dataContext)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                bool isTokenValid = AttachAccountToContext(context, dataContext, token);

                if (isTokenValid)
                {
                    await _next(context);
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    var bytes = Encoding.UTF8.GetBytes("Invalid token or token is expired");

                    await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
                }

            }
            else
            {
                await _next(context);
            }

        }

        /// <summary>
        /// Attach token issued user to httpcontext for more business rule validation
        /// </summary>
        /// <param name="context">HTTP context on which request is being run</param>
        /// <param name="dataContext">A database context for data flow</param>
        /// <param name="token">A jwt token issued for a user during authentication</param>
        /// <returns></returns>
        private bool AttachAccountToContext(HttpContext context, MeroBoleeDbContext dataContext, string token)
        {
            try
            {
                if (!context.Request.Path.StartsWithSegments("/Authenticate"))
                {
                    // context.Request.HttpContext.User.Identity
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidIssuer = _jwtSettings.Issuer,
                        ValidAudience = _jwtSettings.Issuer,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    var jwtToken = (JwtSecurityToken)validatedToken;
                    //int accountId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                    AuthenticateResponse requestUser = JsonConvert.DeserializeObject<AuthenticateResponse>(jwtToken.Claims.First(x => x.Type == "user").Value);

                    // attach account to context on successful jwt validation
                    //TokenUser user = null;
                    //string _cacheKey = $"{CacheKeys.LoginUser}_{accountId}";
                    //if (!cache.TryGetValue<TokenUser>(_cacheKey, out user))
                    //{
                    //    //user = await dataContext.UserEntities.FindAsync(accountId);

                    //    user = (from u in dataContext.UserEntities
                    //            join uc in dataContext.UserCompanies on u.User_Id equals uc.UserId
                    //            join c in dataContext.CompanyEntities on uc.CompanyId equals c.CompanyId
                    //            join r in dataContext.RoleEntities on u.Role_Id equals r.Role_Id
                    //            where u.User_Id == accountId
                    //            select new TokenUser
                    //            {
                    //                UserId = u.User_Id,
                    //                UserStatusId = u.Status_id.Value,
                    //                CompanyId = c.CompanyId,
                    //                FirstName = u.First_Name,
                    //                MiddleName = u.Middle_Name,
                    //                LastName = u.Last_Name,
                    //                Email = u.Person_email,
                    //                AssignedRole = r.Role_Name,
                    //                CompanyName = c.Name,
                    //                CompanyEmail = c.CompanyEmail,
                    //                CompanyCode = c.ReferenceCode,
                    //                CompanyStatusId = c.CompanyStatusId.Value
                    //            }
                    //        ).FirstOrDefault();

                    //    cache.Set<TokenUser>(_cacheKey, user);
                    //}
                    context.Items["RequestUser"] = requestUser;
                    return true;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;
                // do nothing if jwt validation fails
                // account is not attached to context so request won't have access to secure routes
            }
        }
    }
}