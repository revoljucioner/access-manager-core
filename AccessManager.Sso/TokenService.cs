using AccessManager.Models.DataModels;
using AccessManager.Sso.Certificates;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AccessManager.Sso
{
    public class TokenService
    {
        private readonly SigningAudienceCertificate signingAudienceCertificate;
        private readonly TimeSpan _tokenTtl;

        public TokenService(IConfiguration configuration)
        {
            signingAudienceCertificate = new SigningAudienceCertificate();
            _tokenTtl = configuration.GetValue<TimeSpan>("TokenTtl");
        }

        public string GetToken(UserModel user)
        {
            SecurityTokenDescriptor tokenDescriptor = GetTokenDescriptor(user);

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        private SecurityTokenDescriptor GetTokenDescriptor(UserModel user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Email", user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_tokenTtl),
                SigningCredentials = signingAudienceCertificate.GetAudienceSigningKey()
            };

            return tokenDescriptor;
        }
    }
}