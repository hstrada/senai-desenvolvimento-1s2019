using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Infra.Data.Interfaces;
using Senai.Svigufo.WebApi.ViewModels.Convite;

namespace Senai.Svigufo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConviteController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IConviteRepository _conviteRepository;

        public ConviteController(IConviteRepository conviteRepository, IMapper mapper)
        {
            _conviteRepository = conviteRepository;
            _mapper = mapper;
        }

        // GET
        // /convite
        [HttpGet]
        public IActionResult GetConvites()
        {
            return Ok();
        }

        // /convite/aprovados
        // /convite/pendentes

        // POST
        // /convite/entrar
        [HttpPost("entrar")]
        public IActionResult PostEntrarEvento([FromBody] ConviteViewModel viewModel)
        {
            try
            {
                // precisa alterar para pegar o id do usuário logado
                _conviteRepository.EntrarEvento(_mapper.Map<ConviteDomain>(viewModel));
                return Ok("Você entrou no evento.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // /convite/convidar
        [HttpPost("convidar")]
        public IActionResult PostConvidarEvento([FromBody] ConviteViewModel viewModel)
        {

            try
            {
                // precisa alterar para pegar o id do usuário logado
                _conviteRepository.EntrarEvento(_mapper.Map<ConviteDomain>(viewModel));
                return Ok("Você entrou no evento.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // PUT
        // /convite/restrito/aprovar
        // /convite/aprovar

    }
}