using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Threading;
using System.Web;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Logging;

namespace CreditApprover.Authentication
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;
            if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
            {
                return false;
            }
            var bearerToken = authzHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {

            // string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjgyMDgwOTAzMjQiLCJuYmYiOjE1NTg5NTkwOTIsImV4cCI6MTU1OTgyMzA5MiwiaWF0IjoxNTU4OTU5MDkyLCJ1c2VyRGF0YSI6IntcIklkXCI6MCxcIk1vYmlsZU5vXCI6ODIwODA5MDMyNCxcIlBhc3N3b3JkXCI6bnVsbCxcIlVzZXJJZFwiOm51bGwsXCJGaXJzdE5hbWVcIjpudWxsLFwiTGFzdE5hbWVcIjpudWxsLFwiUGhvdG9cIjpudWxsLFwiTG9naW5cIjpudWxsfSJ9.NWRLLmJebQjQx7v1T5C5PCppeGRk8NwxEDRRkgdzmHo";
            // TokenManager.GetPrincipal(token);
            string token;
            HttpStatusCode statusCode;
           TryRetrieveToken(actionContext.Request, out token);
            
            //determine whether a jwt exists or not
            //if (!TryRetrieveToken(request, out token))
            //{
            //    statusCode = HttpStatusCode.Unauthorized;
            //    //allow requests with no token - whether a action method needs an authentication can be set with the claimsauthorization attribute
            //    return base.SendAsync(request, cancellationToken);
            //}

            try
            {
                const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
                var now = DateTime.UtcNow;
                var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));


                SecurityToken securityToken;
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidAudience = "http://localhost:50191",
                    ValidIssuer = "http://localhost:50191",
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = securityKey
                };
                IdentityModelEventSource.ShowPII = true;
                //extract and assign the user of the jwt
                Thread.CurrentPrincipal = handler.ValidateToken(token, validationParameters, out securityToken);
                HttpContext.Current.User = handler.ValidateToken(token, validationParameters, out securityToken);

                //return base.SendAsync(request, cancellationToken);
            }
            catch (SecurityTokenValidationException e)
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            catch (Exception ex)
            {
                statusCode = HttpStatusCode.InternalServerError;
            }
           // return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode) { });
        }
        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }

    }
}
