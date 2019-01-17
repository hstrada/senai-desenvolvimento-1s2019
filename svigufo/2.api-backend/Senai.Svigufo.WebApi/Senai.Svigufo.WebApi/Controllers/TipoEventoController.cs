using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Infra.Data.Interfaces;
using Senai.Svigufo.WebApi.ViewModels;

namespace Senai.Svigufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEventoController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly ITipoEventoRepository _tipoEventoRepository;
        public TipoEventoController(ITipoEventoRepository tipoEventoRepository, IMapper mapper)
        {
            _tipoEventoRepository = tipoEventoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
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
        //[Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult GetTipoEvento(int id)
        {
            TipoEventoViewModel tipoEvento = _mapper.Map<TipoEventoViewModel>(_tipoEventoRepository.BuscarPorId(id));
            if (tipoEvento == null)
            {
                return NotFound();
            }
            return Ok(tipoEvento);
        }

        [HttpPost]
        //[Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult PostTipoEvento([FromBody] TipoEventoViewModel viewModel)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(_mapper.Map<TipoEventoDomain>(viewModel));
                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        //[Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult PutTipoEvento([FromBody] TipoEventoViewModel viewModel)
        {
            try
            {
                _tipoEventoRepository.Atualizar(_mapper.Map<TipoEventoDomain>(viewModel));
                return Ok("Tipo do Evento atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "ADMINISTRADOR")]
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