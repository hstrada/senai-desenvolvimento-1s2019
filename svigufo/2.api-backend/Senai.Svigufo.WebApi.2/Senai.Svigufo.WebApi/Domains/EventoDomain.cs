using System;

namespace Senai.Svigufo.WebApi.Domains
{
    public class EventoDomain
    {
        public int Id { get; set; }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataEvento { get; set; }
        public bool AcessoLivre { get; set; }
        public TipoEventoDomain TipoEvento { get; set; }

    }
}
