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
using Senai.Svigufo.WebApi.ViewModels.Convite;
using Senai.Svigufo.WebApi.ViewModels.Evento;

namespace Senai.Svigufo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IEventoRepository _eventoRepository;
        public EventoController(IEventoRepository eventoRepository, IMapper mapper)
        {
            _eventoRepository = eventoRepository;
            _mapper = mapper;
        }
        
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetEventos()
        {
            return Ok(_eventoRepository.Listar().ToList());
        }

        [HttpPost]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult PostEvento([FromBody] EventoViewModel viewModel)
        {
            try
            {
                _eventoRepository.Cadastrar(_mapper.Map<EventoDomain>(viewModel));
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("palestrante")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult PostEventoPalestrante([FromBody] PalestranteViewModel viewModel)
        {
            try
            {
                _eventoRepository.CadastrarPalestrante(viewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}