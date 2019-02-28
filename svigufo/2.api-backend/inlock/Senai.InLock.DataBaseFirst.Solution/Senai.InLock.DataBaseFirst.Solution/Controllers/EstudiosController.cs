using Microsoft.AspNetCore.Mvc;
using Senai.InLock.DataBaseFirst.Interfaces;
using Senai.InLock.DataBaseFirst.Repositories;
using Senai.InLock.DataBaseFirst.Solution.Domains;
using System.Linq;

namespace Senai.InLock.DataBaseFirst.Solution.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository EstudioRepository { get; set; }


        public EstudiosController()
        {
            EstudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var estudios = EstudioRepository.Listar();

                return Ok(estudios.ToList());
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
                Estudios estudioBuscado = EstudioRepository.BuscarPorId(id);

                if(estudioBuscado == null)
                {
                    return NotFound();
                }

                return Ok(estudioBuscado);
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(Estudios estudio)
        {
            try
            {
                EstudioRepository.Cadastrar(estudio);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }
    }
}