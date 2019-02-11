using System;
using System.Collections.Generic;

namespace Senai.HRoads.Infra.Data.EF.Models
{
    public partial class TiposHabilidades
    {
        public TiposHabilidades()
        {
            Habilidades = new HashSet<Habilidades>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Habilidades> Habilidades { get; set; }
    }
}
