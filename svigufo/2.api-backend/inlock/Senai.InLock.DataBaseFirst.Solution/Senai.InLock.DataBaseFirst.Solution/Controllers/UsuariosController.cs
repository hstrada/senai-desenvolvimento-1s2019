using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.DataBaseFirst.Interfaces;
using Senai.InLock.DataBaseFirst.Repositories;

namespace Senai.InLock.DataBaseFirst.Solution.Controllers
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

        [Authorize(Roles = "ADMINISTRADOR")]
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