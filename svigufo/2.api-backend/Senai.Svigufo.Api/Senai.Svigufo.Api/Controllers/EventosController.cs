using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.Api.Domains;
using Senai.Svigufo.Api.Interfaces;
using Senai.Svigufo.Api.Repositories;

namespace Senai.Svigufo.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {

        public IEventoRepository EventoRepositorio { get; set; }

        public EventosController()
        {
            EventoRepositorio = new EventoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(EventoRepositorio.Listar());
        }
        
        [HttpPost]
        public IActionResult Post(EventoDomain evento)
        {
            try
            {
                EventoRepositorio.Cadastrar(evento);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, EventoDomain evento)
        {
            try
            {
                EventoRepositorio.Atualizar(id, evento);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
