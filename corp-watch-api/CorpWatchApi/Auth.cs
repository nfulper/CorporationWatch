using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CorpWatchApi.Models;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CorpWatchApi
{
    public class Auth
    {
        private IConfiguration _config;
        public Auth(IConfiguration config)
        {
            _config = config;
            secret = _config["Jwt:Key"];
        }
        private static string secret;

        public string GenerateJWT(User user)
        {
            var payload = new Dictionary<string, object>
                {
                    {"username", user.Username},
                    {"role", user.Role}
                };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
            // IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            // IJsonSerializer serializer = new JsonNetSerializer();
            // IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            // IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            // return encoder.Encode(payload, secret);
        }

        // public static bool IsValidToken(string token)
        // {
        //     try
        //     {
        //         IJsonSerializer serializer = new JsonNetSerializer();
        //         IDateTimeProvider provider = new UtcDateTimeProvider();
        //         IJwtValidator validator = new JwtValidator(serializer, provider);
        //         IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
        //         IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

        //         var json = decoder.Decode(token, secret, verify: true);
        //         return true;
        //     }
        //     catch (Exception)
        //     {
        //         return false;
        //     }
        // }
        public string Hash(string password, string salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes(salt), 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            return Convert.ToBase64String(hash);
        }
        public string GenerateSalt()
        {
            return Convert.ToBase64String(GenerateSaltBytes());
        }
        private byte[] GenerateSaltBytes()
        {
            byte[] salt;
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt = new byte[16]);
            return salt;
        }
    }
}