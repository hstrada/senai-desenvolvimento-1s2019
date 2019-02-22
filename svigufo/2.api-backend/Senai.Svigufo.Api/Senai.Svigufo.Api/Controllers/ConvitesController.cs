using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.Api.Domains;
using Senai.Svigufo.Api.Domains.Enums;
using Senai.Svigufo.Api.Interfaces;
using Senai.Svigufo.Api.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Senai.Svigufo.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConvitesController : ControllerBase
    {

        public IConviteRepository ConviteRepositorio { get; set; }

        public ConvitesController()
        {
            ConviteRepositorio = new ConviteRepository();
        }
        
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Put(ConviteDomain convite, int id)
        {
            try
            {
                ConviteRepositorio.Alterar(convite, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        [Route("listar")]
        public IActionResult ListarTodos()
        {
            return Ok(ConviteRepositorio.Listar());
        }

        [Authorize]
        [HttpPost("entrar/{eventoid}")]
        public IActionResult Incricao(int eventoid)
        {
            try
            {
                int usuarioid = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                ConviteDomain convite = new ConviteDomain
                {
                    EventoId = eventoid,
                    UsuarioId = usuarioid,
                    Situacao = EnSituacaoConvite.AGUARDANDO
                };

                ConviteRepositorio.Cadastrar(convite);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }

        [HttpPost]
        [Authorize]
        [Route("convidar")]
        public IActionResult Convite(ConviteDomain convite)
        {
            try
            {
                ConviteRepositorio.Cadastrar(convite);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }

        [Authorize]
        [HttpGet]
        [Route("meus")]
        public IActionResult MeusConvites()
        {
            int usuarioid = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            return Ok(ConviteRepositorio.ListarMeusConvites(usuarioid));
        }
        
    }
}
