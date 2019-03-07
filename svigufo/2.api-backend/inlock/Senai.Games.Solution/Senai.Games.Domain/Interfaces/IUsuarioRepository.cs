using Senai.Games.Domain.Domains;
using System.Collections.Generic;

namespace Senai.Games.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// cadastra um novio usuário
        /// </summary>
        /// <param name="usuario">UsuarioDomain</param>
        void Cadastrar(UsuarioDomain usuario);

        /// <summary>
        /// Lista os usuarios
        /// </summary>
        /// <returns>List<UsuarioDomain></returns>
        List<UsuarioDomain> Listar();

        /// <summary>
        /// Busca um usuário pelo email e senha
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna o UsuarioDomain ou Null</returns>
        UsuarioDomain BuscarEmailSenha(string email, string senha);
    }
}
