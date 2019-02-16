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
        /// <summary>
        /// Cadastrar um novo tipo de evento
        /// </summary>
        /// <param name="tipoEvento">TipoEventoDomain</param>
        void Cadastrar(TipoEventoDomain tipoEvento);

        /// <summary>
        /// Alterar um tipo de evento já cadastrado
        /// </summary>
        /// <param name="tipoEvento"></param>
        void Alterar(TipoEventoDomain tipoEvento);

        /// <summary>
        /// Buscar somente um tipo de evento
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>TipoEventoDomain</returns>
        TipoEventoDomain BuscarPorId(int id);

        /// <summary>
        /// Listar todos os tipos de eventos cadastrados
        /// </summary>
        /// <returns>Lista de tipos de eventos</returns>
        List<TipoEventoDomain> Listar();

        #region Deleção
        /// <summary>
        /// Deletar um tipo de evento cadastrado
        /// </summary>
        /// <param name="id">Id</param>
        void Deletar(int id);
        #endregion
    }
}
