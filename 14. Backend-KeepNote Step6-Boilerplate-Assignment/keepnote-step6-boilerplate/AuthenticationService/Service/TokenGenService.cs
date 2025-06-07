using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;

namespace AuthenticationService.Service
{
    public class TokenGenService : ITokenGenService
    {
        public string GenerateJwtToken(string userId)
        {
            var claims = new[]
            { 
                new Claim(ClaimTypes.Name, userId)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_secret_key_to_authenticate_user_to_valid_responses"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "karthik",
                audience: "stackroute",
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
