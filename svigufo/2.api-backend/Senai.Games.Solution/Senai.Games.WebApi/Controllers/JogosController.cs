using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Senai.Games.Domain.Domains;
using Senai.Games.Domain.Interfaces;
using Senai.Games.Repository.Repositories;

namespace Senai.Games.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogoRepository JogoRepository { get; set; }
        
        public JogosController()
        {
            JogoRepository = new JogoRepository();
        }

        [HttpGet("todos")]
        public IActionResult Listar()
        {
            try
            {
                var Jogos = JogoRepository.Listar();

                return Ok(Jogos.ToList());
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                JogoDomain JogoBuscado = JogoRepository.BuscarPorId(id);

                if (JogoBuscado == null)
                {
                    return NotFound();
                }

                return Ok(JogoBuscado);
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(JogoDomain Jogo)
        {
            try
            {
                JogoRepository.Cadastrar(Jogo);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }
    }
}