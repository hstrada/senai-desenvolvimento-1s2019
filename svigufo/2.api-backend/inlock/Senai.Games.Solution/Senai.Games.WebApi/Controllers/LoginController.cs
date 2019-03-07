using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Games.Domain.Domains;
using Senai.Games.Domain.Interfaces;
using Senai.Games.Repository.Repositories;
using Senai.Games.WebApi.ViewModels;

namespace Senai.Games.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }


        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }


        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                //Busca o usurio pelo email e senha
                UsuarioDomain usuarioBuscado = UsuarioRepository.BuscarEmailSenha(login.Email, login.Senha);

                //Verifica se o usuário foi bus
                if (usuarioBuscado == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Email ou senha inválido"
                    });
                }

                //Define os dados que serão fornecidos no token - PayLoad
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.UsuarioId.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario),
                    new Claim("teste", "laranja")
                };

                // Chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("games-chave-autenticacao"));

                //Credenciais do Token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Gera o token
                var token = new JwtSecurityToken(
                    issuer: "Games.WebApi",
                    audience: "Games.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                //Retorna Ok com o Token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}