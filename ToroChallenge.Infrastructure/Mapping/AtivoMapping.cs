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
            builder.Property(a => a.Symbol)
                .HasColumnType("varchar(6)")
                .HasConversion<string>();
        }
    }
}
