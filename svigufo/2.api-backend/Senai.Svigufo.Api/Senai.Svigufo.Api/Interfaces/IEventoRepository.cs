using Senai.Svigufo.Api.Domains;
using System.Collections.Generic;

namespace Senai.Svigufo.Api.Interfaces
{
    public interface IEventoRepository
    {
        /// <summary>
        /// Listar todos os eventos
        /// </summary>
        /// <returns>Retorna uma lista de eventos</returns>
        List<EventoDomain> Listar();

        EventoDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastrar um novo evento
        /// </summary>
        /// <param name="evento">EventoDomain</param>
        void Cadastrar(EventoDomain evento);

        /// <summary>
        /// Atualizar um evento existente
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="evento">EventoDomain</param>
        void Atualizar(int id, EventoDomain evento);



    }
}
