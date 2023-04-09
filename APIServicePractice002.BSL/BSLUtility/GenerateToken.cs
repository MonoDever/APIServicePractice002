using APIServicePractice002.DTO.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APIServicePractice002.BSL.BSLUtility
{
    public class GenerateToken
    {
        private IConfiguration _configuration;
        public GenerateToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateToken(UserEntity userEntity)
        {
            string result = "";
            if (userEntity != null)
            {
                result = BuildToken(userEntity);
            }
            return result;
        }

        private string BuildToken(UserEntity user)
        {
            var token = new JwtSecurityToken();
            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:Expires"]));

                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, user.name),
                new Claim(JwtRegisteredClaimNames.Email, user.email),
                new Claim("ApiServicePractice002","Learn JWT By Self Practice"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Issuer"],
                    claims,
                    expires: expires,
                    signingCredentials: creds
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
