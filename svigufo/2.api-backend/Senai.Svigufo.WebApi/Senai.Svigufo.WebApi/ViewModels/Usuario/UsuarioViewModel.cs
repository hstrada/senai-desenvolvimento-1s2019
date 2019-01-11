using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.ViewModels.Usuario
{
    public class UsuarioViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(200, ErrorMessage = "O nome não pode ser superior a 200 caracteres.")]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public string TipoUsuario { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve conter 8 caracteres.")]
        public string Cep { get; set; }

        [StringLength(2, MinimumLength = 2, ErrorMessage = "A UF deve conter 2 caracteres.")]
        public string Uf { get; set; }

        public string Cidade { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
