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

            builder.HasIndex(p => new { p.PatrimonioId, p.AtivoId }).IsUnique();
            builder.HasOne(p => p.Patrimonio);
            builder.HasOne(p => p.Ativo);
        }
    }
}
