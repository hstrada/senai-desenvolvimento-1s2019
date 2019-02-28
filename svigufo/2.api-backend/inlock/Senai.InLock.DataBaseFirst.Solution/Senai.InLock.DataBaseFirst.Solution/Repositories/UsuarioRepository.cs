using Senai.InLock.DataBaseFirst.Interfaces;
using Senai.InLock.DataBaseFirst.Solution.Domains;
using System.Collections.Generic;
using System.Linq;

namespace Senai.InLock.DataBaseFirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Busca um usuário pelo email e senha
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna o UsuarioDomain ou Null</returns>
        public Usuarios BuscarEmailSenha(string email, string senha)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
            }
        }

        /// <summary>
        /// cadastra um novio usuário
        /// </summary>
        /// <param name="usuario">UsuarioDomain</param>
        public void Cadastrar(Usuarios usuario)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Lista os usuarios
        /// </summary>
        /// <returns>List<UsuarioDomain></returns>
        public List<Usuarios> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
    }
}
