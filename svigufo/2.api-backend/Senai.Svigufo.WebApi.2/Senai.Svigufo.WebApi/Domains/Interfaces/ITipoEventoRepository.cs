using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Infra.Data.Interfaces
{
    public interface ITipoEventoRepository
    {
        #region Gravação
        void Cadastrar(TipoEventoDomain tipoEventoDomain);
        void Atualizar(TipoEventoDomain tipoEventoDomain);
        void Deletar(int id);
        #endregion

        #region Leitura
        IEnumerable<TipoEventoDomain> Listar();
        TipoEventoDomain BuscarPorId(int id);
        #endregion

    }
}
