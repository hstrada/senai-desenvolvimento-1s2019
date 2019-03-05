using Microsoft.EntityFrameworkCore;
using Senai.Games.Domain.Domains;
using System;

namespace Senai.Games.Repository.Context
{
    public class GamesContext : DbContext
    {
                
        public DbSet<JogoDomain> Jogos { get; set; }
        public DbSet<EstudioDomain> Estudios { get; set; }
        public DbSet<UsuarioDomain> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SqlExpress;database=InLock_Games;trusted_connection=true;");
            base.OnConfiguring(optionsBuilder); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioDomain>().HasData(
            new UsuarioDomain
            {
               UsuarioId = 1, Email = "admin@admin.com", Senha = "admin", TipoUsuario = "ADMINISTRADOR"
            }, 
            new UsuarioDomain
            {
                UsuarioId = 2, Email = "cliente@cliente.com", Senha = "cliente", TipoUsuario = "CLIENTE"
            });

            modelBuilder.Entity<EstudioDomain>().HasData(
                new EstudioDomain { EstudioId = 1, NomeEstudio = "Square Enix" },
                new EstudioDomain { EstudioId = 2, NomeEstudio = "Blizzard" },
                new EstudioDomain { EstudioId = 3, NomeEstudio = "Rockstar Studios" });

            modelBuilder.Entity<JogoDomain>().HasData(
            new JogoDomain
            {
               JogoId =1, Nome = "Diablo 3", DataLancamento = Convert.ToDateTime("15/05/2012"), Descricao = "É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã",
               Valor = Convert.ToDecimal("99,00"),  EstudioId = 2
            },
            new JogoDomain
            {
                JogoId = 2, Nome = "Red Dead Redemption II", DataLancamento = Convert.ToDateTime("26/10/2018"), Descricao = "Jogo eletrônico de ação-aventura western",
                Valor = Convert.ToDecimal("120,00"), EstudioId = 3
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
