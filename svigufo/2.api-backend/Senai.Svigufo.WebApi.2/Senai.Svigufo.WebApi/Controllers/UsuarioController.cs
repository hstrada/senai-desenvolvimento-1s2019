using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Domains.Enum;
using Senai.Svigufo.WebApi.Infra.Data.Interfaces;
using Senai.Svigufo.WebApi.ViewModels.Usuario;

namespace Senai.Svigufo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Cadastrar([FromBody] UsuarioViewModel usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return Ok(usuario);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("Ocorreu um erro ao realizar a inserção do usuário.");
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetUsuarios()
        {
            return Ok(_usuarioRepository.Listar().ToList());
        }

        /// <summary>
        /// Retorna as permissões dos usuários
        /// </summary>
        [HttpGet("tipos")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult GetTiposUsuarios()
        {
            return Ok(Enum.GetNames(typeof(EnTiposUsuario)));
        }
    }
}