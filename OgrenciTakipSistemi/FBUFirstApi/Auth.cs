using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FBUFirstApi
{
    public class Auth : IJwtAuth
    {
        private readonly string _username = "yzc";
        private readonly string _password = "yzc";

        private readonly string adminUser = "admin";
        private readonly string adminPwd = "admin";
        private readonly string key;
        public Auth(string key)
        {
            this.key = key;
        }
        public string Authentication(string username, string password)
        {
            int userId = 1;
            if (!(username.Equals(_username) || password.Equals(_password))&& !(username.Equals(adminUser) || password.Equals(adminPwd)))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(key);
            string role = username == adminUser ? "admin" : "user";

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username), new Claim("userId",userId.ToString()),
                        new Claim(ClaimTypes.Role,role)
                    }
                    ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }

    }
}
