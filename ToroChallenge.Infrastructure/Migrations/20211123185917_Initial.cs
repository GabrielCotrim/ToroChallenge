using Microsoft.EntityFrameworkCore.Migrations;

namespace ToroChallenge.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "identidade");

            migrationBuilder.CreateTable(
                name: "tb_ativos",
                schema: "identidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "varchar", nullable: true),
                    CurrentPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ativos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_usuarios",
                schema: "identidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apelido = table.Column<string>(type: "varchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_patrimonios",
                schema: "identidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<double>(type: "float", nullable: false),
                    TotalAtivos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_patrimonios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_patrimonios_tb_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "identidade",
                        principalTable: "tb_usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_patrimonio_ativos",
                schema: "identidade",
                columns: table => new
                {
                    PatrimonioId = table.Column<int>(type: "int", nullable: false),
                    AtivoId = table.Column<int>(type: "int", nullable: false),
                    QuantidadeAtivos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_patrimonio_ativos", x => new { x.PatrimonioId, x.AtivoId });
                    table.ForeignKey(
                        name: "FK_tb_patrimonio_ativos_tb_ativos_AtivoId",
                        column: x => x.AtivoId,
                        principalSchema: "identidade",
                        principalTable: "tb_ativos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_patrimonio_ativos_tb_patrimonios_PatrimonioId",
                        column: x => x.PatrimonioId,
                        principalSchema: "identidade",
                        principalTable: "tb_patrimonios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_patrimonio_ativos_AtivoId",
                schema: "identidade",
                table: "tb_patrimonio_ativos",
                column: "AtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_patrimonios_UsuarioId",
                schema: "identidade",
                table: "tb_patrimonios",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_patrimonio_ativos",
                schema: "identidade");

            migrationBuilder.DropTable(
                name: "tb_ativos",
                schema: "identidade");

            migrationBuilder.DropTable(
                name: "tb_patrimonios",
                schema: "identidade");

            migrationBuilder.DropTable(
                name: "tb_usuarios",
                schema: "identidade");
        }
    }
}
