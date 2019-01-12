using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Domains
{
    public class ConviteDomain
    {
        public int Id { get; set; }
        
        public int IdUsuario { get; set; }
        
        public int IdEvento { get; set; }

        public bool Palestrante { get; set; }

        public bool Aprovado { get; set; }
    }
}
