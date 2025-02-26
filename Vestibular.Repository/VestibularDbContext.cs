using Microsoft.EntityFrameworkCore;
using Vestibular.Repository.Entities;

namespace Vestibular.Repository
{
    public class VestibularDbContext : DbContext
    {
        public VestibularDbContext(DbContextOptions<VestibularDbContext> options)
            : base(options) { }

        public VestibularDbContext() { }

        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Inscricao> Inscricao { get; set; }
        public DbSet<ProcessoSeletivo> ProcessoSeletivo { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=Vestibular.db");
            }
        }
    }
}