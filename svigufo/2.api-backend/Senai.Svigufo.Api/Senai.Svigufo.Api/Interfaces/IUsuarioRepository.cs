using Senai.Svigufo.Api.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.Api.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(UsuarioDomain usuario);
    }
}
