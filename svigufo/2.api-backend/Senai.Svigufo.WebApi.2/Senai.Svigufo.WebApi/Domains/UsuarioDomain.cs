using Senai.Svigufo.WebApi.Domains.Enum;

namespace Senai.Svigufo.WebApi.Domains
{
    public class UsuarioDomain
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        // public string TipoUsuario { get; set; }
        public EnTiposUsuario TipoUsuario { get; set; }
        
        // segunda etapa
        // public EnderecoDomain Endereco { get; set; }
    }
}
