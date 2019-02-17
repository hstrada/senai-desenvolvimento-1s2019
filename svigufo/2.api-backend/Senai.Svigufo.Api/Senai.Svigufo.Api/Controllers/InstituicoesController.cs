using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.Api.Domains;
using Senai.Svigufo.Api.Interfaces;
using Senai.Svigufo.Api.Repositories;

namespace Senai.Svigufo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicoesController : ControllerBase
    {
        private IInstituicaoRepository InstituicaoRepository { get; set; }
        
        public InstituicoesController()
        {
            InstituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// Buscar a lista de instituições
        /// </summary>
        /// <returns>Lista de Instituições</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(InstituicaoRepository.Listar());
        }

        /// <summary>
        /// Buscar somente uma instituição
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Apenas uma instituição</returns>
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

        /// <summary>
        /// Cadastrar uma nova instituição
        /// </summary>
        /// <param name="instituicao">InstituicaoDomain</param>
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

        /// <summary>
        /// Atualizar uma instituição
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="instituicao">InstituicaoDomain</param>
        /// <returns></returns>
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