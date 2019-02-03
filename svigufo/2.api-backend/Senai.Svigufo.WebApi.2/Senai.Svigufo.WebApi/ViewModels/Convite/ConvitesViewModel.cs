using Senai.Svigufo.WebApi.Domains.Enum;
using System;

namespace Senai.Svigufo.WebApi.ViewModels.Convite
{
    public class ConvitesViewModel
    {
        public int Id { get; set; }
        public EnSituacaoConvite Situacao { get; set; }
        public string Titulo { get; set; }
        public DateTime DataEvento { get; set; }
        public string TipoEvento { get; set; }
    }
}
