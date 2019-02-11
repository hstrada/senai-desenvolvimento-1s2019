namespace Senai.HRoads.Domain.Entidades
{
    public class Habilidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual Tipo_Habilidade TipoHabilidade { get; set; }
        public int Id_Tipo_Habilidade { get; set; }
    }
}
