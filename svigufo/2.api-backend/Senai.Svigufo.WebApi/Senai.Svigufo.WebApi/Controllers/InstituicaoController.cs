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
using Senai.Svigufo.WebApi.ViewModels.Instituicao;

namespace Senai.Svigufo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IInstituicaoRepository _instituicaoRepository;
        public InstituicaoController(IInstituicaoRepository instituicaoRepository, IMapper mapper)
        {
            _instituicaoRepository = instituicaoRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult PostIntituicao([FromBody] InstituicaoViewModel viewModel)
        {
            try
            {
                _instituicaoRepository.Cadastrar(_mapper.Map<InstituicaoDomain>(viewModel));
                return Ok("Instituição inserida com sucesso.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult PutInstituicao([FromBody] InstituicaoViewModel viewModel)
        {
            try
            {
                _instituicaoRepository.Atualizar(_mapper.Map<InstituicaoDomain>(viewModel));
                return Ok("Instituição inserida com sucesso.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult GetInstituicao(int id)
        {
            InstituicaoViewModel instituicao = _mapper.Map<InstituicaoViewModel>(_instituicaoRepository.BuscarPorId(id));
            if (instituicao == null)
            {
                return NotFound();
            }
            return Ok(instituicao);
        }


    }
}