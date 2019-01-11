using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.WebApi.Infra.Data.Interfaces;
using Senai.Svigufo.WebApi.Util;
using Senai.Svigufo.WebApi.ViewModels.Usuario;

namespace Senai.Svigufo.WebApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class LoginController : ControllerBase
    //{
    //    [AllowAnonymous]
    //    [HttpPost]
    //    public IActionResult Login([FromBody] LoginViewModel login)
    //    {
    //        if ((login.Email != "admin@email.com") || (login.Senha != "123456"))
    //               return BadRequest("Usuário ou senha inválidas.");
    //        var token = new TokenUtil().GenerateToken(login.Email, 1.ToString(), "COMUM");
    //        return Ok(new
    //        {
    //            token = new JwtSecurityTokenHandler().WriteToken(token)
    //        });
    //    }
    //}

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginViewModel login)
        {
            LoginViewModel usuarioBuscado = _mapper.Map<LoginViewModel>(_usuarioRepository.Login(login.Email, login.Senha));
            if (usuarioBuscado == null)
                return BadRequest("Usuário ou senha inválidas.");

            var token = new TokenUtil().GenerateToken(usuarioBuscado.Email, usuarioBuscado.Id.ToString(), usuarioBuscado.TipoUsuario);
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}