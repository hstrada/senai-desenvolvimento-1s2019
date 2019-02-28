using Microsoft.EntityFrameworkCore;
using Senai.InLock.DataBaseFirst.Interfaces;
using Senai.InLock.DataBaseFirst.Solution.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senai.InLock.DataBaseFirst.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        /// <summary>
        /// Busca um jogo pelo seu Id
        /// </summary>
        /// <param name="id">Id do Jogo</param>
        /// <returns>Retorna um JogoDomain ou Null</returns>
        public Jogos BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.Include("Estudio").FirstOrDefault(g => g.JogoId == id);

            }
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="jogo">JogoDomain</param>
        public void Cadastrar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Lista todos os Jogos
        /// </summary>
        /// <returns>List<JogoDomain></returns>
        public List<Jogos> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.Include(x => x.Estudio).ToList();

            }
        }
    }
}
