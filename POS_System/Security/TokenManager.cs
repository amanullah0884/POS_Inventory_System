﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace POS_System.Security
{
    public class TokenManager : ITokenManager
    {
        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKeysuperSecretKey@345"));

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                //issuer: configuration["Jwt:Issuer"],
                //audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
        //public class TokenManager : ITokenManager
        //{
        //    private readonly IConfiguration _configuration;

        //    public TokenManager(IConfiguration configuration)
        //    {
        //        _configuration = configuration;
        //    }

        //    public string GenerateAccessToken(IEnumerable<Claim> claims)
        //    {
        //        var key = _configuration["Jwt:Key"];
        //        var issuer = _configuration["Jwt:Issuer"];
        //        var audience = _configuration["Jwt:Audience"];

        //        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        //        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        //        var tokenOptions = new JwtSecurityToken(
        //            issuer: issuer,
        //            audience: audience,
        //            claims: claims,
        //            expires: DateTime.Now.AddMinutes(30),
        //            signingCredentials: signinCredentials
        //        );

        //        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        //    }
        //}
    }
}
