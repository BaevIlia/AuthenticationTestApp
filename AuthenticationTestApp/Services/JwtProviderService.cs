using AuthenticationTestApp.Database;
using AuthenticationTestApp.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using AuthenticationTestApp.Interfaces;

namespace AuthenticationTestApp.Services
{
    public class JwtProviderService : IJwtProviderService
    {
        private readonly JwtOptions _options;
        public JwtProviderService(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public string GenerateToken(User user) 
        {
            Claim[] claims = [
                new("userId", user.Id.ToString()),
                new("Admin", "true")
                ]; 
            var signingCredentinals = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentinals,
                expires: DateTime.UtcNow.AddHours(_options.ExpitesHours)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
