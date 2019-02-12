using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.Api.Domains;
using Senai.Svigufo.Api.Interfaces;
using Senai.Svigufo.Api.Repositories;
using System;

namespace Senai.Svigufo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicoesController : ControllerBase
    {
        private IInstituicaoRepository InstituicaoRepository { get; set; }
        // repositório
        public InstituicoesController()
        {
            InstituicaoRepository = new InstituicaoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(InstituicaoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            InstituicaoDomain instituicao = InstituicaoRepository.BuscarPorId(id);
            if (instituicao == null)
            {
                return NotFound();
            }
            return Ok(instituicao);
        }

        [HttpPost]
        public IActionResult Post(InstituicaoDomain instituicao)
        {
            try
            {
                InstituicaoRepository.Cadastrar(instituicao);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, InstituicaoDomain instituicao)
        {
            InstituicaoDomain buscada = InstituicaoRepository.BuscarPorId(id);
            if (buscada == null)
            {
                return NotFound();
            }
            try
            {
                instituicao.Id = id;
                InstituicaoRepository.Alterar(instituicao);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
            
        }
    }
}