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
        public IActionResult Cadastrar([FromBody] UsuarioViewModel usuario)
        {
            _usuarioRepository.Cadastrar(usuario);
            return Ok(usuario);
        }

        [HttpGet]
        // [Authorize]
        public IActionResult GetUsuarios()
        {
            return Ok(_usuarioRepository.Listar().ToList());
        }
    }
}