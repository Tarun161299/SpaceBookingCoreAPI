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
            var userDetail = (from d in dbContext.UserDetail
                              join rm in dbContext.UserRoleMapping on d.Username equals rm.UserName
                              join r in dbContext.RoleMaster on rm.RoleId equals r.RoleId
                              where rm.UserName == User.UserName && d.Password == User.Password
                              select new UserLoginDetails
                              {
                                  UserName = rm.UserName,
                                  role = r.RoleName
                              }).ToList();
            if (userDetail.Count>0)
            {
                var token = this.GenerateJwtToken(userDetail[0].UserName, userDetail[0].role);
                return token;
            }
            else
            {
                return "Invalid User";
            }

        }

        private string GenerateJwtToken(string UserName,string role)

        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes("xxxxxxxsssssssdddddddaaaaaaaaaaaaaa");

            var tokenDescriptor = new SecurityTokenDescriptor

            {

                Subject = new ClaimsIdentity(new[] { new Claim("id", UserName), new Claim(ClaimTypes.Role, role) }),

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
