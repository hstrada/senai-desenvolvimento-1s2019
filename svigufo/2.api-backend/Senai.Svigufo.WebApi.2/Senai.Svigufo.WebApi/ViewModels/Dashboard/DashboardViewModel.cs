using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        public int Usuarios { get; set; }
        public int EventosPublicos { get; set; }
        public int EventosPrivados { get; set; }
        public int TiposEventos { get; set; }
    }
}
