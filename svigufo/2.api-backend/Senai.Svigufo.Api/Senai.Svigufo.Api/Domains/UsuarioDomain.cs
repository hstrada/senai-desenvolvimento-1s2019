using System.ComponentModel.DataAnnotations;

namespace Senai.Svigufo.Api.Domains
{
    public class UsuarioDomain
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        public string TipoUsuario { get; set; }

    }
}
