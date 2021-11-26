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

            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Usuario);
            builder.HasMany(p => p.PatrimonioAtivos);
            builder.HasData(
                new Patrimonio
                {
                    Id = 1,
                    UsuarioId = 1,
                    Saldo = 100.0
                }
            );
        }
    }
}
