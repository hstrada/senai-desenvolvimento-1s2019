using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Senai.Svigufo.Api.Domains;

namespace Senai.Svigufo.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposEventosController : ControllerBase
    {

        List<TipoEventoDomain> eventos = new List<TipoEventoDomain>() {
            new TipoEventoDomain { Id = 1, Nome = "Tipo Evento A" }
            ,new TipoEventoDomain { Id = 2, Nome = "Tipo Evento B" }
            ,new TipoEventoDomain { Id = 3, Nome = "Tipo Evento C" }
            ,new TipoEventoDomain { Id = 4, Nome = "Tipo Evento D" }
        };

        //[HttpGet]
        //public string Get()
        //{
        //    return "Requisição Recebida com Sucesso.";    
        //}

        [HttpGet]
        public IEnumerable<TipoEventoDomain> Get()
        {
            return eventos;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TipoEventoDomain evento = eventos.Find(x => x.Id == id);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        [HttpPost]
        public IActionResult Post(TipoEventoDomain tipoEvento) {

            eventos.Add(new TipoEventoDomain() { Id = eventos.Count + 1, Nome = tipoEvento.Nome });
            return Ok(eventos);
            //tipoEvento.Id = eventos.Count + 1;
            //return Ok(tipoEvento);
        }

        [HttpPut]
        public IActionResult Put(TipoEventoDomain tipoEvento) {
            var eventoEncontrado = eventos.Find(x => x.Id == tipoEvento.Id);
            eventoEncontrado.Nome = tipoEvento.Nome;

            return Ok(eventos);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            eventos.Remove(eventos.Find(x => x.Id == id));
            return Ok(eventos);
        }
    }
}
