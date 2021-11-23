using Microsoft.EntityFrameworkCore;
using ToroChallenge.Application.Utils.Configurations;
using ToroChallenge.Domain.Entities;
using ToroChallenge.Infrastructure.Mapping;

namespace ToroChallenge.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<Patrimonio> Patrimonios { get; set; }
        public DbSet<PatrimonioAtivos> PatrimonioAtivos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer(Configurations.GetDefaultConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AtivoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new PatrimonioMapping());
            modelBuilder.ApplyConfiguration(new PatrimonioAtivosMapping());
        }
    }
}
