using Senai.Games.Domain.Domains;
using System.Collections.Generic;

namespace Senai.Games.Domain.Interfaces
{
    public interface IJogoRepository
    {
        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="jogo">JogoDomain</param>
        void Cadastrar(JogoDomain jogo);

        /// <summary>
        /// Lista todos os Jogos
        /// </summary>
        /// <returns>List<JogoDomain></returns>
        List<JogoDomain> Listar();


        /// <summary>
        /// Busca um jogo pelo seu Id
        /// </summary>
        /// <param name="id">Id do Jogo</param>
        /// <returns>Retorna um JogoDomain ou Null</returns>
        JogoDomain BuscarPorId(int id);
    }
}
