using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.ViewModels
{
    public class EventosViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Palestrante { get; set; }
    }
}
