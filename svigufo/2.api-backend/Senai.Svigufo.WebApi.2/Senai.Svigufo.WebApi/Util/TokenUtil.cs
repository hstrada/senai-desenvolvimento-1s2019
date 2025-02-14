﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Util
{
    public class TokenUtil
    {
        private const string JwtKey = "abcdefghijklmnopqrstuvwxyz";
        private const string TokenIssuer = "svigufo";

        public JwtSecurityToken GenerateToken(string email, string id, string permissao)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(ClaimTypes.Role, permissao),
                new Claim(JwtRegisteredClaimNames.Jti, id),
                new Claim("id", id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(TokenIssuer,
                TokenIssuer,
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            return token;
        }

        public int GetIdFromToken(string token)
        {
           
            return Int32.Parse(new JwtSecurityToken(token).Id);
        }

        public string GetPermissaoFromToken(string token)
        {
            var claims = new JwtSecurityToken(token).Claims;
            IEnumerable<Claim> permissao = claims.Where(x => x.Type == ClaimTypes.Role);
            var tipoPermissao = permissao.FirstOrDefault().Value;
            return tipoPermissao;
        }
        
    }
}
