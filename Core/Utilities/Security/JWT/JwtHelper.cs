﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } //appsettingsi okumaya yarıyor.
        private TokenOptions _tokenOptions; //okunulan nesneleri bir nesneye atıcam. biz jwt içerisinde olusturduk.
        private DateTime _accessTokenExpiration; //access token ne zaman degersizlesecek ? 
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            //Konfigürasyondaki alanı bul. GetSection. -> appsettingsteki "x": içinde yazan alan
            //Ve onu şu sınıfın değerlerini kullanark maple. Eşitle demek.

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)//user ve claim'e göre token olusturrur.
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);//tokenin süresi
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);//güvenlik anahtarı
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);//hangi algoritma ve anahtar ne
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims); //ortaya jwt üretimi çıkar.
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken( //istenilen bilgileri burada veriyor.
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEMail(user.EMail);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
