using System;
using System.Collections.Generic;

namespace Senai.HRoads.Infra.Data.EF.Models
{
    public partial class Personagens
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? CapMaxVida { get; set; }
        public int? CapMaxMana { get; set; }
        public DateTime? DtCriacao { get; set; }
        public DateTime? DtAtualizacao { get; set; }
        public int? IdClasse { get; set; }

        public Classes IdClasseNavigation { get; set; }
    }
}
