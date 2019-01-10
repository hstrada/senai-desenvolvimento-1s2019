using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.Domain;
using Senai.Svigufo.Infra.Data.Repositories;
using Senai.Svigufo.ViewModels.Usuario;

namespace Senai.Svigufo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private UsuarioRepository _usuarioRepository = new UsuarioRepository();

        // 5.2 - Criar um UsuarioDomain
        // UsuarioDomain administrador = new UsuarioDomain("admin@email.com", "123456");

        // 1
        // [HttpGet]
        //[HttpPost]
        //public IActionResult Login([FromBody] string email)
        //{
        //    // "email@email.com" 
        //    return Ok("Login efetuado com sucesso.");
        //}

        // 2
        //[HttpPost]
        //public IActionResult Login([FromBody] string email)
        //{
        //    if (email == "admin@email.com")
        //    {
        //        return Ok("Login efetuado com sucesso.");
        //    }
        //    return NotFound();
        //}

        // 3
        [HttpGet]
        public IActionResult RealizandoUmaRequisicao()
        {
            return Ok("Realizando uma requisição");
        }

        // 4
        [HttpGet("{id}")]
        public IActionResult RecebendoUmParametroParaBuscar(long id)
        {
            return Ok("Buscando o id: " + id);
        }

        // 5
        [HttpPut]
        public IActionResult AtualizandoUmRegistro([FromBody] UsuarioDomain usuarioAtualizado)
        {

            return Ok("Atualizado com sucesso.");
        }

        // 6
        [HttpDelete("{id}")]
        public IActionResult RecebendoUmParametroParaDeletar(long id)
        {
            return Ok("Deletando o id: " + id);
        }

        //// 9
        //[HttpPost]
        //// public IActionResult Login([FromBody] LoginDomain loginDomain)
        //public IActionResult Login([FromBody] LoginViewModel loginViewModel)
        //{
        //    // este valor nao sera fixado, ele precisara vir do banco
        //    if (loginViewModel.Email == "admin@email.com")
        //    {
        //        return Ok(loginViewModel);
        //    }
        //    return NotFound();
        //}

        // 10
        [HttpPost]
        // public IActionResult Login([FromBody] LoginDomain loginDomain)
        public IActionResult Login([FromBody] LoginViewModel loginViewModel)
        {

            UsuarioViewModel usuario = _usuarioRepository.BuscarPorEmailSenha(loginViewModel);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);

        }

    }
}