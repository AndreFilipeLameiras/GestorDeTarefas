using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Data.GestorDeTarefasMigrations
{
    public partial class email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_SistemaProdutividade_SistemaProdutividadeId",
                table: "Colaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_SistemaProdutividade_Colaborador_ColaboradorId",
                table: "SistemaProdutividade");

            migrationBuilder.DropIndex(
                name: "IX_SistemaProdutividade_ColaboradorId",
                table: "SistemaProdutividade");

            migrationBuilder.DropIndex(
                name: "IX_Colaborador_SistemaProdutividadeId",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "ColaboradorId",
                table: "SistemaProdutividade");

            migrationBuilder.DropColumn(
                name: "SistemaProdutividadeId",
                table: "Colaborador");

            migrationBuilder.CreateTable(
                name: "ColaboradorProdutividade",
                columns: table => new
                {
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    SistemaProdutividadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradorProdutividade", x => new { x.ColaboradorId, x.SistemaProdutividadeId });
                    table.ForeignKey(
                        name: "FK_ColaboradorProdutividade_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "ColaboradorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColaboradorProdutividade_SistemaProdutividade_SistemaProdutividadeId",
                        column: x => x.SistemaProdutividadeId,
                        principalTable: "SistemaProdutividade",
                        principalColumn: "SistemaProdutividadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorProdutividade_SistemaProdutividadeId",
                table: "ColaboradorProdutividade",
                column: "SistemaProdutividadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColaboradorProdutividade");

            migrationBuilder.AddColumn<int>(
                name: "ColaboradorId",
                table: "SistemaProdutividade",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SistemaProdutividadeId",
                table: "Colaborador",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SistemaProdutividade_ColaboradorId",
                table: "SistemaProdutividade",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_SistemaProdutividadeId",
                table: "Colaborador",
                column: "SistemaProdutividadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_SistemaProdutividade_SistemaProdutividadeId",
                table: "Colaborador",
                column: "SistemaProdutividadeId",
                principalTable: "SistemaProdutividade",
                principalColumn: "SistemaProdutividadeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SistemaProdutividade_Colaborador_ColaboradorId",
                table: "SistemaProdutividade",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
