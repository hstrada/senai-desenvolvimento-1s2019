using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.ViewModels;
using Senai.Svigufo.WebApi.ViewModels.Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Infra.Data.Interfaces
{
    public interface IEventoRepository
    {
        #region Gravação
        void Cadastrar(EventoDomain eventoDomain);
        void Atualizar(EventoDomain eventoDomain);
        #endregion

        #region Leitura
        IEnumerable<EventosViewModel> Listar();
        #endregion
    }
}
