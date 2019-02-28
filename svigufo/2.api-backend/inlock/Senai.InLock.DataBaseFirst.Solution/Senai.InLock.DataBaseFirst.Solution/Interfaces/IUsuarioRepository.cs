using Senai.InLock.DataBaseFirst.Solution.Domains;
using System.Collections.Generic;

namespace Senai.InLock.DataBaseFirst.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// cadastra um novio usuário
        /// </summary>
        /// <param name="usuario">UsuarioDomain</param>
        void Cadastrar(Usuarios usuario);

        /// <summary>
        /// Lista os usuarios
        /// </summary>
        /// <returns>List<UsuarioDomain></returns>
        List<Usuarios> Listar();

        /// <summary>
        /// Busca um usuário pelo email e senha
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna o UsuarioDomain ou Null</returns>
        Usuarios BuscarEmailSenha(string email, string senha);
    }
}
