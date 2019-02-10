using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.Api.Domains;

namespace Senai.Svigufo.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
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

    }
}
