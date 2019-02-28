using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.DataBaseFirst.Interfaces;
using Senai.InLock.DataBaseFirst.Repositories;
using Senai.InLock.DataBaseFirst.Solution.Domains;
using Senai.InLock.DataBaseFirst.Solution.ViewModels;

namespace Senai.InLock.DataBaseFirst.Solution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        public IHostingEnvironment _env { get; set; }
        private IJogoRepository JogoRepository { get; set; }

        public JogosController(IHostingEnvironment env)
        {
            JogoRepository = new JogoRepository();
            _env = env;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var Jogos = JogoRepository.Listar();

                return Ok(Jogos.ToList());
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Jogos JogoBuscado = JogoRepository.BuscarPorId(id);

                if (JogoBuscado == null)
                {
                    return NotFound();
                }

                return Ok(JogoBuscado);
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CadastrarJogoViewModel jogo)
        {
            try
            {
                var caminhoArquivo = Path.GetTempFileName();

                var uploads = Path.Combine(_env.WebRootPath, "uploads");
                if (jogo.Imagem.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, jogo.Imagem.FileName), FileMode.Create))
                    {
                        await jogo.Imagem.CopyToAsync(fileStream);
                    }
                }

                Jogos jogoTemporario = new Jogos();

                JogoRepository.Cadastrar(jogoTemporario);

                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }
    }
}