using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TalentNode.Domain.interfaces;
using TalentNode.Domain.Models;
using TalentNode.Infrastructure.Data;

namespace TalentNode.Infrastructure.Repositories
{
    public class UserAuthenticationRepository(TalentNodeDbContext dbContext): IUserAuthenticationRepository
    {
        public async Task<string> AuthenticateUser (UserDetails User)
        {
            if(User.UserName=="Tarun123" && User.Password == "Test@123")
            {
                var token = this.GenerateJwtToken();
                return token;
            }
            else
            {
                return "Invalid User";
            }

        }

        private string GenerateJwtToken()

        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes("xxxxxxxsssssssdddddddaaaaaaaaaaaaaa");

            var tokenDescriptor = new SecurityTokenDescriptor

            {

                Subject = new ClaimsIdentity(new[] { new Claim("id", "testuser"), new Claim(ClaimTypes.Role, "Admin") }),

                Issuer = "https://localhost:7054",

                Audience = "https://localhost:7054",

                Expires = DateTime.UtcNow.AddDays(7),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
