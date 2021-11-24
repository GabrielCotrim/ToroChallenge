using Microsoft.EntityFrameworkCore.Migrations;

namespace ToroChallenge.Infrastructure.Migrations
{
    public partial class AdicionaPropriedadeUniqueNaEntidadeAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tb_ativos_symbol",
                schema: "identidade",
                table: "tb_ativos",
                column: "symbol",
                unique: true,
                filter: "[symbol] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_ativos_symbol",
                schema: "identidade",
                table: "tb_ativos");
        }
    }
}
