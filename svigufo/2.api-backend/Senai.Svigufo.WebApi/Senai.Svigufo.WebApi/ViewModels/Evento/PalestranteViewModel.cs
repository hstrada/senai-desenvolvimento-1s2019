using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.ViewModels.Evento
{
    public class PalestranteViewModel
    {
        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public int IdEvento { get; set; }

        public bool Palestrante { get; set; } = true;
        public bool Aprovado { get; set; } = true;
    }
}
