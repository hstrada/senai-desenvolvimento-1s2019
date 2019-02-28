using Senai.InLock.DataBaseFirst.Solution.Domains;
using System.Collections.Generic;

namespace Senai.InLock.DataBaseFirst.Interfaces
{
    public interface IJogoRepository
    {
        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="jogo">JogoDomain</param>
        void Cadastrar(Jogos jogo);

        /// <summary>
        /// Lista todos os Jogos
        /// </summary>
        /// <returns>List<JogoDomain></returns>
        List<Jogos> Listar();


        /// <summary>
        /// Busca um jogo pelo seu Id
        /// </summary>
        /// <param name="id">Id do Jogo</param>
        /// <returns>Retorna um JogoDomain ou Null</returns>
        Jogos BuscarPorId(int id);
    }
}
