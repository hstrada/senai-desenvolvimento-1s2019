using System;
using System.Collections.Generic;

namespace Senai.HRoads.Infra.Data.EF.Models
{
    public partial class Classes
    {
        public Classes()
        {
            Personagens = new HashSet<Personagens>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Personagens> Personagens { get; set; }
    }
}
