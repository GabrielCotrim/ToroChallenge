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

            builder.Property(a => a.Symbol)
                .HasColumnType("varchar")
                .HasConversion<string>();
            builder.Property(a => a.CurrentPrice)
                .HasColumnType("numeric")
                .HasConversion<double>();
            builder.HasMany(p => p.PatrimonioAtivos);
        }
    }
}
