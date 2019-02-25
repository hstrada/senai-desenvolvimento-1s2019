using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Games.Domain.Interfaces;
using Senai.Games.Repository.Repositories;

namespace Senai.Games.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [Authorize("ADMINISTRADOR")]
        [HttpGet("todos")]
        public IActionResult Listar()
        {
            try
            {
                var Usuarios = UsuarioRepository.Listar();

                return Ok(Usuarios.ToList());
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }

    }
}