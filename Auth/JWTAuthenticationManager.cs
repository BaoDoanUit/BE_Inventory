
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MineralInventory.Auth
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(string username, string password);
    }

    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        private readonly string tokenKey;
        public JWTAuthenticationManager(string tokenKey)
        {
            this.tokenKey = tokenKey;
        }
        public string Authenticate(string username, string password)
        {
            Console.WriteLine("Authenticate: " + username);
            var tokenHandler = new JwtSecurityTokenHandler();
            Console.WriteLine(tokenKey);
            // var signinKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenKey));
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenKey));
            Console.WriteLine("KeySize: " + key.KeySize.ToString());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(
                   key, SecurityAlgorithms.HmacSha256)
            };
            Console.WriteLine("Token Descriptor: Authenticate");
            // var signInCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);
            // var claims = new Claim[] { new Claim(ClaimTypes.Name, username)};
            // var jwt = new JwtSecurityToken(claims: claims, signingCredentials: signInCredentials);
            var jwt = tokenHandler.CreateToken(tokenDescriptor);
            Console.WriteLine(tokenHandler.WriteToken(jwt));
            return tokenHandler.WriteToken(jwt);
        }
    }
}