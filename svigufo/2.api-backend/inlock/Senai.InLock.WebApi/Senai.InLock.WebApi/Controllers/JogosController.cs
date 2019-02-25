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
    public class JogosController : ControllerBase
    {

        private readonly InLockDbContext _context;

        public JogosController(InLockDbContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Listar todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Jogos.Include(j => j.Estudio).ToList());
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Post(Jogos jogo)
        {
            try
            {
                return Ok(_context.Jogos.Add(jogo));
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

    }
}
