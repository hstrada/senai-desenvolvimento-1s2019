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

        // [Required]
        public string TipoUsuario { get; set; }
        
    }
}
