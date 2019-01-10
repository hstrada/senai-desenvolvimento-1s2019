using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.WebApi.Infra.Data.Interfaces;
using Senai.Svigufo.WebApi.ViewModels;

namespace Senai.Svigufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEventoController : ControllerBase
    {
        private readonly ITipoEventoRepository _tipoEventoRepository;
        public TipoEventoController(ITipoEventoRepository tipoEventoRepository)
        {
            _tipoEventoRepository = tipoEventoRepository;
        }

        [HttpGet]
        public IActionResult GetTiposEventos()
        {
            return Ok(_tipoEventoRepository.Listar().ToList());
        }

        /// <summary>
        /// Busca um tipo de evento por Id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Retorna o tipo de evento buscado.</response>
        /// <response code="404">Caso o tipo de evento buscado não seja encontrado.</response>           
        [HttpGet("{id}")]
        public IActionResult GetTipoEvento(int id)
        {
            TipoEventoViewModel tipoEvento = _tipoEventoRepository.BuscarPorId(id);
            if (tipoEvento == null)
            {
                return NotFound();
            }
            return Ok(tipoEvento);
        }

        [HttpPost]
        public IActionResult PostTipoEvento([FromBody] TipoEventoViewModel viewModel)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(viewModel);
                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutTipoEvento([FromBody] TipoEventoViewModel viewModel)
        {
            try
            {
                _tipoEventoRepository.Atualizar(viewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTipoEvento(int id)
        {
            try
            {
                _tipoEventoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}