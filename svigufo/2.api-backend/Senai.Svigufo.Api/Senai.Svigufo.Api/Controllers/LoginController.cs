using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.Api.Domains;
using Senai.Svigufo.Api.Interfaces;
using Senai.Svigufo.Api.Repositories;
using Senai.Svigufo.Api.ViewModels;

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
                UsuarioDomain usuario = UsuarioRepository.BuscarPorEmailESenha(login);
                if (usuario == null)
                {
                    return NotFound(
                        new {
                            mensagem = "Usuário não foi encontrado."
                        }
                    );
                }
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
            
        }
        
    }
}
