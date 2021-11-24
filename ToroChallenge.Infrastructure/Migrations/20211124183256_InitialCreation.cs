using Microsoft.EntityFrameworkCore.Migrations;

namespace ToroChallenge.Infrastructure.Migrations
{
    public partial class InitialCreation : Migration
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
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    symbol = table.Column<string>(type: "varchar(6)", nullable: true),
                    current_price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ativos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_usuarios",
                schema: "identidade",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    apelido = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_patrimonios",
                schema: "identidade",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    saldo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_patrimonios", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_patrimonios_tb_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalSchema: "identidade",
                        principalTable: "tb_usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_patrimonio_ativos",
                schema: "identidade",
                columns: table => new
                {
                    patrimonio_id = table.Column<int>(type: "int", nullable: false),
                    ativo_id = table.Column<int>(type: "int", nullable: false),
                    quantidade_ativos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_patrimonio_ativos", x => new { x.patrimonio_id, x.ativo_id });
                    table.ForeignKey(
                        name: "FK_tb_patrimonio_ativos_tb_ativos_ativo_id",
                        column: x => x.ativo_id,
                        principalSchema: "identidade",
                        principalTable: "tb_ativos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_patrimonio_ativos_tb_patrimonios_patrimonio_id",
                        column: x => x.patrimonio_id,
                        principalSchema: "identidade",
                        principalTable: "tb_patrimonios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "identidade",
                table: "tb_ativos",
                columns: new[] { "id", "current_price", "symbol" },
                values: new object[,]
                {
                    { 1, 28.440000000000001, "PETR4" },
                    { 2, 25.91, "MGLU3" },
                    { 3, 25.91, "VVAR3" },
                    { 4, 40.770000000000003, "SANB11" },
                    { 5, 115.98, "TORO4" },
                    { 6, 0.90000000000000002, "OIBR3" }
                });

            migrationBuilder.InsertData(
                schema: "identidade",
                table: "tb_usuarios",
                columns: new[] { "id", "apelido" },
                values: new object[] { 1, "Usuário Mock" });

            migrationBuilder.InsertData(
                schema: "identidade",
                table: "tb_patrimonios",
                columns: new[] { "id", "saldo", "usuario_id" },
                values: new object[] { 1, 100.0, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_tb_ativos_symbol",
                schema: "identidade",
                table: "tb_ativos",
                column: "symbol",
                unique: true,
                filter: "[symbol] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tb_patrimonio_ativos_ativo_id",
                schema: "identidade",
                table: "tb_patrimonio_ativos",
                column: "ativo_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_patrimonios_usuario_id",
                schema: "identidade",
                table: "tb_patrimonios",
                column: "usuario_id");
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
