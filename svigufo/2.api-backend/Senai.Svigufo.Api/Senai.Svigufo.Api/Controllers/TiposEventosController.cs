using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Senai.Svigufo.Api.Domains;
using Senai.Svigufo.Api.Interfaces;
using Senai.Svigufo.Api.Repositories;

namespace Senai.Svigufo.Api.Controllers
{
    /// <summary>
    /// Classe controladora para tipos de eventos
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposEventosController : ControllerBase
    {

        private ITipoEventoRepository TipoEventoRepositorio { get; set; }

        public TiposEventosController()
        {
            TipoEventoRepositorio = new TipoEventoRepository();
        }

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

        /// <summary>
        /// Retorna a lista de tipos de eventos
        /// </summary>
        /// <returns>
        /// Retorna a lista de tipos de eventos
        /// </returns>
        [HttpGet]
        public IEnumerable<TipoEventoDomain> Get()
        {
            // return eventos;
            return TipoEventoRepositorio.Listar();
        }

        /// <summary>
        /// Busca somente um tipo de evento cadastrado
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Retorna um tipo de evento encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // TipoEventoDomain evento = eventos.Find(x => x.Id == id);
            TipoEventoDomain evento = TipoEventoRepositorio.BuscarPorId(id);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        /// <summary>
        /// Cadastrar um novo tipo de evento
        /// </summary>
        /// <param name="tipoEvento"></param>
        /// <returns>Retorna a lista atualizada</returns>
        [HttpPost]
        public IActionResult Post(TipoEventoDomain tipoEvento)
        {

            //eventos.Add(new TipoEventoDomain() { Id = eventos.Count + 1, Nome = tipoEvento.Nome });
            //return Ok(eventos);
            //tipoEvento.Id = eventos.Count + 1;
            //return Ok(tipoEvento);
            try
            {
                TipoEventoRepositorio.Cadastrar(tipoEvento);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Atualiza um tipo de evento
        /// </summary>
        /// <param name="tipoEvento"></param>
        /// <returns>Retorna a lista de atualizada de tipos de eventos</returns>
        [HttpPut]
        public IActionResult Put(TipoEventoDomain tipoEvento)
        {
            var eventoEncontrado = eventos.Find(x => x.Id == tipoEvento.Id);
            eventoEncontrado.Nome = tipoEvento.Nome;

            return Ok(eventos);
        }

        /// <summary>
        /// Deleta um tipo de evento dado um determinado id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna a lista atualizada</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            eventos.Remove(eventos.Find(x => x.Id == id));
            return Ok(eventos);
        }
    }
}
