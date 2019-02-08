using Senai.Svigufo.WebApi.Domains.Enum;

namespace Senai.Svigufo.WebApi.Domains
{
    public class ConviteDomain
    {
        public int Id { get; set; }
        
        public int IdUsuario { get; set; }
        
        public int IdEvento { get; set; }

        public EnSituacaoConvite Situacao { get; set; }
    }
}
