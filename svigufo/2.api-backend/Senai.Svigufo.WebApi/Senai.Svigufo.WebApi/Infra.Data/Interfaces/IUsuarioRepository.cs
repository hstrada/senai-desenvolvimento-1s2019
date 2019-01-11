using Senai.Svigufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Infra.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        #region Leitura
        UsuarioDomain Login(string email, string senha);
        #endregion
    }
}
