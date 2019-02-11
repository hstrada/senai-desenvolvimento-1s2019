using System;
using System.Collections.Generic;

namespace Senai.HRoads.Infra.Data.EF.Models
{
    public partial class Habilidades
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? IdTipoHabilidade { get; set; }

        public TiposHabilidades IdTipoHabilidadeNavigation { get; set; }
    }
}
