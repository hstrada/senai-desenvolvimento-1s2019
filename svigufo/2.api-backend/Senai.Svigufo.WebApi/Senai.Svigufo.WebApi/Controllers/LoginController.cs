using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
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

        private readonly IUsuarioRepository _usuarioRepository;
        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginViewModel login)
        {
            if ((login.Email != "admin@email.com") || (login.Senha != "123456"))
                return BadRequest("Usuário ou senha inválidas.");
            var token = new TokenUtil().GenerateToken(login.Email, 1.ToString(), "COMUM");
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}