using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToroChallenge.Application.Utils.Constantes;
using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Infrastructure.Mapping
{
    public class AtivoMapping : IEntityTypeConfiguration<Ativo>
    {
        public void Configure(EntityTypeBuilder<Ativo> builder)
        {
            builder.ToTable(TabelasConst.Ativos, SchemasConst.Identidade);

            builder.HasKey(a => a.Id);
            builder.HasIndex(a => a.Symbol).IsUnique();
            builder.Property(a => a.Symbol)
                .HasColumnType("varchar(6)")
                .HasConversion<string>();
            builder.HasData(
                new Ativo { Id = 1, Symbol = "PETR4", CurrentPrice = 28.44 },
                new Ativo { Id = 2, Symbol = "MGLU3", CurrentPrice = 25.91 },
                new Ativo { Id = 3, Symbol = "VVAR3", CurrentPrice = 25.91 },
                new Ativo { Id = 4, Symbol = "SANB11", CurrentPrice = 40.77 },
                new Ativo { Id = 5, Symbol = "TORO4", CurrentPrice = 115.98 },
                new Ativo { Id = 6, Symbol = "OIBR3", CurrentPrice = 0.90 }
            );
        }
    }
}
