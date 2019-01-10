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
        void Cadastrar(TipoEventoViewModel tipoEventoViewModel);
        void Atualizar(TipoEventoViewModel tipoEventoViewModel);
        void Deletar(int id);
        #endregion

        #region Leitura
        IEnumerable<TipoEventoViewModel> Listar();
        TipoEventoViewModel BuscarPorId(int id);
        #endregion

    }
}
