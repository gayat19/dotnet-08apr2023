using AuthenticationAPI.Interfaces;
using AuthenticationAPI.Models.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationAPI.Services
{
    public class TokenService : IGenerateToken
    {
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            string key = configuration.GetSection("secrectKey").Value;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }
        public string GenerateToken(UserDTO user)
        {
            string token = string.Empty;
            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.Username)
            };
            var cred = new SigningCredentials(_key,SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject= new ClaimsIdentity(claims),
                Expires= DateTime.Now.AddDays(1),
                SigningCredentials= cred
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var myToken = tokenHandler.CreateToken(tokenDescriptor);
            token = tokenHandler.WriteToken(myToken);
            return token;
        }
    }
}
