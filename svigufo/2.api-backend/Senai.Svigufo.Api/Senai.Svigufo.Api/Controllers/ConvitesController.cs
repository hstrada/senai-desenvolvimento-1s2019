using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ConviteRepositorio.ListarMeusConvites(Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value)));
        }
        
    }
}
