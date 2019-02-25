using Senai.Games.Domain.Domains;
using Senai.Games.Domain.Interfaces;
using Senai.Games.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Games.Repository.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Busca um usuário pelo email e senha
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna o UsuarioDomain ou Null</returns>
        public UsuarioDomain BuscarEmailSenha(string email, string senha)
        {
            using (GamesContext ctx = new GamesContext())
            {
                return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
            }
        }

        /// <summary>
        /// cadastra um novio usuário
        /// </summary>
        /// <param name="usuario">UsuarioDomain</param>
        public void Cadastrar(UsuarioDomain usuario)
        {
            using (GamesContext ctx = new GamesContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Lista os usuarios
        /// </summary>
        /// <returns>List<UsuarioDomain></returns>
        public List<UsuarioDomain> Listar()
        {
            using (GamesContext ctx = new GamesContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
    }
}
