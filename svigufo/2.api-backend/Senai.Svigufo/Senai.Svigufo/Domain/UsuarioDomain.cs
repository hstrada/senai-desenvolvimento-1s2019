using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.Domain
{
    public class UsuarioDomain
    {
        public int Id { get; set; }
        // 5.1
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        // 6
        // 7 - trocar para enumeracao
        public string TipoUsuario { get; set; }
    }
}
