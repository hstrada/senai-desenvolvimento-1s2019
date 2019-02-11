namespace Senai.HRoads.Infra.Data.EF.Models
{
    public partial class SENAI_HROADSContext : DbContext
    {
        public SENAI_HROADSContext()
        {
        }

        public SENAI_HROADSContext(DbContextOptions<SENAI_HROADSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Habilidades> Habilidades { get; set; }
        public virtual DbSet<Personagens> Personagens { get; set; }
        public virtual DbSet<TiposHabilidades> TiposHabilidades { get; set; }

        // Unable to generate entity type for table 'dbo.CLASSES_HABILIDADES'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classes>(entity =>
            {
                entity.ToTable("CLASSES");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__CLASSES__E2AB1FF4D2C54A54")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Habilidades>(entity =>
            {
                entity.ToTable("HABILIDADES");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__HABILIDA__E2AB1FF4CDFF08E1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdTipoHabilidade).HasColumnName("ID_TIPO_HABILIDADE");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoHabilidadeNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTipoHabilidade)
                    .HasConstraintName("FK__HABILIDAD__ID_TI__4D94879B");
            });

            modelBuilder.Entity<Personagens>(entity =>
            {
                entity.ToTable("PERSONAGENS");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__PERSONAG__E2AB1FF47556AFB8")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CapMaxMana).HasColumnName("CAP_MAX_MANA");

                entity.Property(e => e.CapMaxVida).HasColumnName("CAP_MAX_VIDA");

                entity.Property(e => e.DtAtualizacao)
                    .HasColumnName("DT_ATUALIZACAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtCriacao)
                    .HasColumnName("DT_CRIACAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdClasse).HasColumnName("ID_CLASSE");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Personagens)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__PERSONAGE__ID_CL__571DF1D5");
            });

            modelBuilder.Entity<TiposHabilidades>(entity =>
            {
                entity.ToTable("TIPOS_HABILIDADES");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__TIPOS_HA__E2AB1FF43C9E0A41")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
