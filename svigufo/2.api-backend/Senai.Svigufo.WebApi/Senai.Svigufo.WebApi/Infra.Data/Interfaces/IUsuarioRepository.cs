using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.ViewModels.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Infra.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        #region Gravação
        void Cadastrar(UsuarioViewModel usuario);
        #endregion

        #region Leitura
        UsuarioDomain Login(string email, string senha);
        IEnumerable<UsuarioViewModel> Listar();
        #endregion
    }
}
