using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.ViewModels.Usuario
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Email é requerido")]
        [MinLength(7)]
        [MaxLength(254)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Senha é requerido")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo Tipo de Usuário é requerido")]
        [MinLength(2)]
        [MaxLength(50)]
        public string TipoUsuario { get; set; }
    }
}
