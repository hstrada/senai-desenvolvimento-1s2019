using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Svigufo.Api.Domains;
using Senai.Svigufo.Api.Interfaces;
using Senai.Svigufo.Api.Repositories;
using Senai.Svigufo.Api.ViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Senai.Svigufo.Api.Controllers
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

        /// <summary>
        /// Buscar um usuario por email e senha
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Retorna uma autenticação para o usuário</returns>
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                // UsuarioDomain usuario = UsuarioRepository.BuscarPorEmailESenha(login);
                UsuarioDomain usuario = UsuarioRepository.BuscarPorEmailESenha(login.Email, login.Senha);
                if (usuario == null)
                {
                    return NotFound(
                        new
                        {
                            mensagem = "Usuário ou senha inválidos."
                        }
                    );
                }
                var claims = new[]
                {
                     new Claim(JwtRegisteredClaimNames.Email, login.Email),
                     new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                     new Claim(ClaimTypes.Role, usuario.TipoUsuario),
                };

                //recebe uma instancia da classe SymmetricSecurityKey 
                //armazenando a chave de criptografia usada na criação do token
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("svigufo-chave-autenticacao"));

                //recebe um objeto do tipo SigninCredentials contendo a chave de 
                //criptografia e o algoritmo de segurança empregados na geração 
                // de assinaturas digitais para tokens
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                     issuer: "Svigufo.WebApi",
                     audience: "Svigufo.WebApi",
                     claims: claims,
                     expires: DateTime.Now.AddMinutes(30),
                     signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }

        }

    }
}
