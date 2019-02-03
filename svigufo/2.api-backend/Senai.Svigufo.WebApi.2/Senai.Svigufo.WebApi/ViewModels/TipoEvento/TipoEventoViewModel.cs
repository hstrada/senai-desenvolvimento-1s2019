using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.ViewModels
{
    public class TipoEventoViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o campo título")]
        public string Titulo { get; set; }
    }
}
