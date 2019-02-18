using Senai.Svigufo.Api.Domains;
using Senai.Svigufo.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.Api.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(UsuarioDomain usuario);

        UsuarioDomain BuscarPorEmailESenha(LoginViewModel login);
        UsuarioDomain BuscarPorEmailESenha(string email, string senha);
    }
}
