using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToroChallenge.Application.Utils.Constantes;
using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Infrastructure.Mapping
{
    public class PatrimonioAtivosMapping : IEntityTypeConfiguration<PatrimonioAtivos>
    {
        public void Configure(EntityTypeBuilder<PatrimonioAtivos> builder)
        {
            builder.ToTable(TabelasConst.PatrimonioAtivos, SchemasConst.Identidade);

            builder.HasKey(p => new { p.PatrimonioId, p.AtivoId });

            builder.HasOne(pa => pa.Patrimonio)
                .WithMany(p => p.PatrimonioAtivos)
                .HasForeignKey(pa => pa.PatrimonioId);
            builder.HasOne(pa => pa.Ativo)
                .WithMany(a => a.PatrimonioAtivos)
                .HasForeignKey(pa => pa.AtivoId);
        }
    }
}
