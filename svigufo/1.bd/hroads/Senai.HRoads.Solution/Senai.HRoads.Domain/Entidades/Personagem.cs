using System;

namespace Senai.HRoads.Domain.Entidades
{
    public class Personagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Cap_Max_Vida { get; set; }
        public int Cap_Max_Mana { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public virtual Classe Classes { get; set; }
        public int Id_Classe { get; set; }
    }
}
