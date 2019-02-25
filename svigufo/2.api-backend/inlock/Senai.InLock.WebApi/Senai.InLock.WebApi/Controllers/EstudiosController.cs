using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Models;
using System.Linq;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")] // Retorna formato Json
    [Route("api/[controller]")]
    [ApiController] //Implementa funcionalidades no Controller
    public class EstudiosController : ControllerBase
    {

        private readonly InLockDbContext _context;

        public EstudiosController(InLockDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Listar todos os estúdios
        /// </summary>
        /// <returns>Uma lista com todos os estúdios</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Estudios.Include(e => e.Jogos).ToList());
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }

        }
    }
}
