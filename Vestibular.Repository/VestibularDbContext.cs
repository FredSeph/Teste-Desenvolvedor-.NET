using Microsoft.EntityFrameworkCore;
using Vestibular.Repository.Entities;

namespace Vestibular.Repository
{
    public class VestibularDbContext : DbContext
    {
        #region Tabelas

        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Inscricao> Inscricao { get; set; }
        public DbSet<ProcessoSeletivo> ProcessoSeletivo { get; set; }

        #endregion

        #region Construtores

        public VestibularDbContext(DbContextOptions<VestibularDbContext> options) : base(options) { }

        public VestibularDbContext() { }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=Vestibular.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inscricao>()
                .HasOne(i => i.ProcessoSeletivo)
                .WithMany(p => p.Inscricoes)
                .HasForeignKey(i => i.IdProcessoSeletivo);

            modelBuilder.Entity<Inscricao>()
                .HasOne(i => i.Candidato)
                .WithMany(c => c.Inscricoes)
                .HasForeignKey(i => i.IdCandidato);

            modelBuilder.Entity<Inscricao>()
                .HasOne(i => i.Curso)
                .WithMany(c => c.Inscricoes)
                .HasForeignKey(i => i.IdCurso);
        }
    }
}