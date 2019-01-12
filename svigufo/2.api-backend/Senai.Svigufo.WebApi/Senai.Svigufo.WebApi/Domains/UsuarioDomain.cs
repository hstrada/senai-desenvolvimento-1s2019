using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Domains
{
    public class UsuarioDomain
    {
        public enum TiposUsuario { COMUM, ADMINISTRADOR };

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        // public string TipoUsuario { get; set; }
        public TiposUsuario TipoUsuario { get; set; }
        
        // segunda etapa
        public EnderecoDomain Endereco { get; set; }
    }
}
