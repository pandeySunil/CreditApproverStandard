using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace CreditApprover.Authantication
{
    class TokenManager
    {
        private static readonly string SecretKey = "XCAP05H6LoKvbRRa/QkqLNMI7cOHguaRyHzyg7n5qEkGjQmtBhz4SzYh4Fqwjyi3KJHlSXKPwVu2+bXr6CtpgQ==";
        private const string DataKey = "userData";
        public static string GenerateToken<TPayloadModel>(string username, TPayloadModel payloadModel)
        {
            try
            {
                byte[] key = Convert.FromBase64String(SecretKey);

                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);

                SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }),
                    Expires = DateTime.UtcNow.AddDays(10),
                    SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
                };

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
                token.Payload[DataKey] = JsonConvert.SerializeObject(payloadModel);
                return handler.WriteToken(token);
            }
            catch
            {
                return string.Empty;
            }
        }


    }
}
