using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToroChallenge.Application.Utils.Constantes;
using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Infrastructure.Mapping
{
    public class PatrimonioMapping : IEntityTypeConfiguration<Patrimonio>
    {
        public void Configure(EntityTypeBuilder<Patrimonio> builder)
        {
            builder.ToTable(TabelasConst.Patrimonios, SchemasConst.Identidade);

            builder.Property(p => p.Saldo)
                .HasColumnType("numeric")
                .HasConversion<double>();
            builder.HasMany(p => p.PatrimonioAtivos);
        }
    }
}
