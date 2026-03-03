using Microsoft.IdentityModel.Tokens;
using Mre.OTI.Presupuesto.Application.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

namespace Mre.OTI.Presupuesto.Infraestructure.Services.JWT
{
    public class TokenJWT : ITokenJWT
    {
        public TokenJWT()
        {

        }
        //public static string Generate(string key, string awg)
        //{
        //    var rsa = RSA.Create();
        //    rsa.ImportRSAPrivateKey(Convert.FromBase64String(key), out _);

        //    var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256);
        //    var header = new JwtHeader(signingCredentials);
        //    var payload = new JwtPayload
        //    {
        //       { "agw", awg },
        //       { "exp", ((int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds) + Convert.ToInt32(60) }
        //    };

        //    var secToken = new JwtSecurityToken(header, payload);
        //    return new JwtSecurityTokenHandler().WriteToken(secToken);
        //}
        public string Generate(string key, string awg)
        {
            var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(key), out _);

            var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256);
            var header = new JwtHeader(signingCredentials);
            var payload = new JwtPayload
            {
               { "agw", awg },
               { "exp", ((int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds) + Convert.ToInt32(60) }
            };

            var secToken = new JwtSecurityToken(header, payload);
            var token = new JwtSecurityTokenHandler().WriteToken(secToken);



            return token;
        }
    }
}
