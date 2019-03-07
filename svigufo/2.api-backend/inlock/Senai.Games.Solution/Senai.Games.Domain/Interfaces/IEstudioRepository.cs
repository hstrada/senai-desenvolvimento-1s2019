using Senai.Games.Domain.Domains;
using System.Collections.Generic;

namespace Senai.Games.Domain.Interfaces
{
    public interface IEstudioRepository
    {
        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="estudio">EstudioDomain</param>
        void Cadastrar(EstudioDomain estudio);

        /// <summary>
        /// Lista todos os Estúdios
        /// </summary>
        /// <returns>List<EstudioDomain></returns>
        List<EstudioDomain> Listar();


        /// <summary>
        /// Busca um estúdio pelo seu Id
        /// </summary>
        /// <param name="id">Id do estúdio</param>
        /// <returns>Retorna um EstudioDomain ou Null</returns>
        EstudioDomain BuscarPorId(int id);
    }
}
