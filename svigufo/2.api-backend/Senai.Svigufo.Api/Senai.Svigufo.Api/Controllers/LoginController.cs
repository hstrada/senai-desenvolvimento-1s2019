using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.Api.Domains;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Senai.Svigufo.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        
        /// <summary>
        /// Buscar um usuario por email e senha
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Retorna uma autenticação para o usuário</returns>
        [HttpPost]
        public IActionResult Post(UsuarioDomain usuario)
        {
            return Ok();
        }
        
    }
}
