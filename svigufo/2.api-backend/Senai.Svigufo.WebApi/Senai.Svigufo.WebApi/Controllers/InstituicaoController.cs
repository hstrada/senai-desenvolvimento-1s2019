using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Svigufo.WebApi.ViewModels.Instituicao;

namespace Senai.Svigufo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult PostIntituicao([FromBody] InstituicaoViewModel viewModel)
        {
            try
            {
                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}