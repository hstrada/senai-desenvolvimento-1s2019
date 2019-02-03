using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Domains.Enum;
using Senai.Svigufo.WebApi.Infra.Data.Interfaces;
using Senai.Svigufo.WebApi.Util;
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
        [Authorize]
        public async Task<IActionResult> GetConvitesAsync()
        {
            IEnumerable<ConvitesViewModel> convites = new List<ConvitesViewModel>();

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var token = new TokenUtil();
            string permissaoUsuario = token.GetPermissaoFromToken(accessToken);
            if (permissaoUsuario == EnTiposUsuario.ADMINISTRADOR.ToString())
            {
                // busca todos
                convites = _conviteRepository.TodosOsEventos();
            }
            else
            {
                // busca somente seus próprios convites
                int idUsuario = token.GetIdFromToken(accessToken);
                convites = _conviteRepository.MeusEventos(idUsuario);
            }
            
            return Ok(convites);
        }

        // /convite/aprovados
        // /convite/pendentes

        // POST
        // /convite/entrar
        [HttpPost("entrar")]
        [Authorize]
        public IActionResult PostEntrarEvento([FromBody] ConviteViewModel viewModel)
        {
            try
            {
                // precisa alterar para que neste caso, o id do usuário, 
                // seja o id do usuário logado pois ele estará entrando no evento
                _conviteRepository.EntrarEvento(_mapper.Map<ConviteDomain>(viewModel));
                return Ok("Você entrou no evento.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // /convite/convidar
        /// <summary>
        /// Enviar um convite para um amigo
        /// </summary>
        [HttpPost("convidar")]
        [Authorize]
        public IActionResult PostConvidarEvento([FromBody] ConviteViewModel viewModel)
        {

            try
            {
                // o id do usuário aqui, será o id do usuário do amigo
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
        [HttpPut("aprovar/{id}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult PutAprovarEventoRestrito(int id)
        {

            _conviteRepository.AprovarConvite(id);
            return Ok();

        }

        // /convite/aprovar

    }
}