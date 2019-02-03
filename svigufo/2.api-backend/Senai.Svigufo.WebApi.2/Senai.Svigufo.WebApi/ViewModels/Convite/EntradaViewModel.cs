using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.ViewModels.Convite
{
    public class EntradaViewModel
    {
        [Required]
        public int IdConvite { get; set; }
    }
}
