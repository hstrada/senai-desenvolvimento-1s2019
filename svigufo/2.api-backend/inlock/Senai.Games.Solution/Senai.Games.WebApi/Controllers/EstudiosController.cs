using Microsoft.AspNetCore.Mvc;
using Senai.Games.Domain.Domains;
using Senai.Games.Domain.Interfaces;
using Senai.Games.Repository.Repositories;
using System.Linq;

namespace Senai.Games.WebApi.Controllers
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
                EstudioDomain estudioBuscado = EstudioRepository.BuscarPorId(id);

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
        public IActionResult Post(EstudioDomain estudio)
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