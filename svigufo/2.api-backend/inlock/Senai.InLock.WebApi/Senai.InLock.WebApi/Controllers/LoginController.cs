using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.InLock.WebApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")] // Retorna formato Json
    [Route("api/[controller]")]
    [ApiController] //Implementa funcionalidades no Controller
    public class LoginController : ControllerBase
    {

        private readonly InLockDbContext _context;

        public LoginController(InLockDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Realizar o login e gerar um token
        /// </summary>
        /// <param name="usuario">Usuario</param>
        /// <returns>Retorna o token gerado, caso tenha sido feito com sucesso</returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post(Usuarios usuario)
        {
            try
            {
                Usuarios usuarioBuscado = _context.Usuarios.Where(u => u.Email == usuario.Email && u.Senha == usuario.Senha).FirstOrDefault();
                if (usuarioBuscado == null)
                {
                    return NotFound(new { mensagem = "Usuário ou senha inválido." });
                }

                var claims = new[]
                {
                     new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                     new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.UsuarioId.ToString()),
                     new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario),
                };
                
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("inlock-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                     issuer: "InLock.WebApi",
                     audience: "InLock.WebApi",
                     claims: claims,
                     expires: DateTime.Now.AddMinutes(30),
                     signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (System.Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

    }
}
