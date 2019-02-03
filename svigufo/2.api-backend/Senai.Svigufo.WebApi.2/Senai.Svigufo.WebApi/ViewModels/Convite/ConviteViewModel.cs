using Senai.Svigufo.WebApi.Domains.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.ViewModels.Convite
{
    public class ConviteViewModel
    {
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public int IdEvento { get; set; }
        
        public EnSituacaoConvite Situacao { get; set; }
    }
}
