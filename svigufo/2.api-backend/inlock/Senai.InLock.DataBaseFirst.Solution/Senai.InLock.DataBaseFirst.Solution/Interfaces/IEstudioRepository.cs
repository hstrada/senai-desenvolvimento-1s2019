using Senai.InLock.DataBaseFirst.Solution.Domains;
using System.Collections.Generic;

namespace Senai.InLock.DataBaseFirst.Interfaces
{
    public interface IEstudioRepository
    {
        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="estudio">EstudioDomain</param>
        void Cadastrar(Estudios estudio);

        /// <summary>
        /// Lista todos os Estúdios
        /// </summary>
        /// <returns>List<EstudioDomain></returns>
        List<Estudios> Listar();


        /// <summary>
        /// Busca um estúdio pelo seu Id
        /// </summary>
        /// <param name="id">Id do estúdio</param>
        /// <returns>Retorna um EstudioDomain ou Null</returns>
        Estudios BuscarPorId(int id);
    }
}
