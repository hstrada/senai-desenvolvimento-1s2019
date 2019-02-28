using Microsoft.EntityFrameworkCore;
using Senai.InLock.DataBaseFirst.Interfaces;
using Senai.InLock.DataBaseFirst.Solution.Domains;
using System.Collections.Generic;
using System.Linq;

namespace Senai.InLock.DataBaseFirst.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// Busca um estúdio pelo seu Id
        /// </summary>
        /// <param name="id">Id do estúdio</param>
        /// <returns>Retorna um EstudioDomain ou Null</returns>
        public Estudios BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return  ctx.Estudios.Include(x => x.Jogos).FirstOrDefault(g => g.EstudioId == id);
                
            }
        }

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="estudio">EstudioDomain</param>
        public void Cadastrar(Estudios estudio)
        {
            using(InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Lista todos os Estúdios
        /// </summary>
        /// <returns>List<EstudioDomain></returns>
        public List<Estudios> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.Include(x => x.Jogos).ToList();
                //Explicar o include
                //return ctx.Estudios.Include("Jogos").ToList();

            }
        }
    }
}
