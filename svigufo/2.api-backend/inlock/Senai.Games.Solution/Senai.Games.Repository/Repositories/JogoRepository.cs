using Microsoft.EntityFrameworkCore;
using Senai.Games.Domain.Domains;
using Senai.Games.Domain.Interfaces;
using Senai.Games.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Games.Repository.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        /// <summary>
        /// Busca um jogo pelo seu Id
        /// </summary>
        /// <param name="id">Id do Jogo</param>
        /// <returns>Retorna um JogoDomain ou Null</returns>
        public JogoDomain BuscarPorId(int id)
        {
            using (GamesContext ctx = new GamesContext())
            {
                return ctx.Jogos.Include("Estudio").FirstOrDefault(g => g.JogoId == id);

            }
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="jogo">JogoDomain</param>
        public void Cadastrar(JogoDomain jogo)
        {
            using (GamesContext ctx = new GamesContext())
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Lista todos os Jogos
        /// </summary>
        /// <returns>List<JogoDomain></returns>
        public List<JogoDomain> Listar()
        {
            using (GamesContext ctx = new GamesContext())
            {
                return ctx.Jogos.Include("Estudio").ToList();
                //Explicar o include
                //return ctx.Estudios.Include("Jogos").ToList();

            }
        }
    }
}
