using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToroChallenge.Application.Utils.Constantes;
using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Infrastructure.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(TabelasConst.Usuarios, SchemasConst.Identidade);

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Apelido)
                .HasColumnType("varchar(30)")
                .HasConversion<string>();
            builder.HasData(
                new Usuario
                {
                    Id = 1,
                    Apelido = "Usuário Mock"
                }
            );
        }
    }
}
