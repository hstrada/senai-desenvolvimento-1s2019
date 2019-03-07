using Microsoft.EntityFrameworkCore;
using Senai.Games.Domain.Domains;
using Senai.Games.Domain.Interfaces;
using Senai.Games.Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Games.Repository.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// Busca um estúdio pelo seu Id
        /// </summary>
        /// <param name="id">Id do estúdio</param>
        /// <returns>Retorna um EstudioDomain ou Null</returns>
        public EstudioDomain BuscarPorId(int id)
        {
            using (GamesContext ctx = new GamesContext())
            {
                return  ctx.Estudios.Include("Games").FirstOrDefault(g => g.EstudioId == id);
                
            }
        }

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="estudio">EstudioDomain</param>
        public void Cadastrar(EstudioDomain estudio)
        {
            using(GamesContext ctx = new GamesContext())
            {
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Lista todos os Estúdios
        /// </summary>
        /// <returns>List<EstudioDomain></returns>
        public List<EstudioDomain> Listar()
        {
            using (GamesContext ctx = new GamesContext())
            {
                return ctx.Estudios.Include("Games").ToList();
                //Explicar o include
                //return ctx.Estudios.Include("Jogos").ToList();

            }
        }
    }
}
