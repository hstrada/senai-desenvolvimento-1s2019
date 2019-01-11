using Senai.Svigufo.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Infra.Data.Interfaces
{
    public interface IEventoRepository
    {
        #region Leitura
        IEnumerable<EventoViewModel> Listar();
        #endregion
    }
}
