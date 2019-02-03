using Senai.Svigufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Infra.Data.Interfaces
{
    public interface IInstituicaoRepository
    {
        #region Gravação
        void Cadastrar(InstituicaoDomain instituicaoDomain);
        void Atualizar(InstituicaoDomain instituicaoDomain);
        #endregion

        #region Leitura
        InstituicaoDomain BuscarPorId(int id);
        #endregion
    }
}
