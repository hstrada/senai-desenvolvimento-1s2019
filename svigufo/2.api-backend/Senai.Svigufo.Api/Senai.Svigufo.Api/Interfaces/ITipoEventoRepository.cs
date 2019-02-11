using Senai.Svigufo.Api.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.Api.Interfaces
{
    /// <summary>
    /// Interface responsável pelo Tipo de Evento Repository
    /// </summary>
    public interface ITipoEventoRepository
    {
        void Cadastrar(TipoEventoDomain tipoEvento);
        void Alterar(TipoEventoDomain tipoEvento);
        TipoEventoDomain BuscarPorId(int id);
        List<TipoEventoDomain> Listar();
        #region Deleção
        void Deletar(int id);
        #endregion
    }
}
