using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.ViewModels.Convite
{
    public class ConvitesViewModel
    {
        public int Id { get; set; }
        public bool Aprovado { get; set; }
        public string Titulo { get; set; }
        public DateTime DataEvento { get; set; }
        public string TipoEvento { get; set; }
    }
}
