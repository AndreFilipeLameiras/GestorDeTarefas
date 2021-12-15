using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Migrations
{
    public partial class ColaboradorProjetoSprint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Cargo_CargoId",
                table: "Colaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorProdutividade_Colaborador_ColaboradorId",
                table: "ColaboradorProdutividade");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorProdutividade_SistemaProdutividade_SistemaProdutividadeId",
                table: "ColaboradorProdutividade");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Colaborador_ColaboradorId",
                table: "Tarefas");

            migrationBuilder.CreateTable(
                name: "ProjetoSprintDesign",
                columns: table => new
                {
                    ID_P_Design = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProjeto = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoSprintDesign", x => x.ID_P_Design);
                });

            migrationBuilder.CreateTable(
                name: "ColaboradorProjetoSprint",
                columns: table => new
                {
                    ID_P_Design = table.Column<int>(type: "int", nullable: false),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradorProjetoSprint", x => new { x.ID_P_Design, x.ColaboradorId });
                    table.ForeignKey(
                        name: "FK_ColaboradorProjetoSprint_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "ColaboradorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ColaboradorProjetoSprint_ProjetoSprintDesign_ID_P_Design",
                        column: x => x.ID_P_Design,
                        principalTable: "ProjetoSprintDesign",
                        principalColumn: "ID_P_Design",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorProjetoSprint_ColaboradorId",
                table: "ColaboradorProjetoSprint",
                column: "ColaboradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Cargo_CargoId",
                table: "Colaborador",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "CargoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorProdutividade_Colaborador_ColaboradorId",
                table: "ColaboradorProdutividade",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorProdutividade_SistemaProdutividade_SistemaProdutividadeId",
                table: "ColaboradorProdutividade",
                column: "SistemaProdutividadeId",
                principalTable: "SistemaProdutividade",
                principalColumn: "SistemaProdutividadeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Colaborador_ColaboradorId",
                table: "Tarefas",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Cargo_CargoId",
                table: "Colaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorProdutividade_Colaborador_ColaboradorId",
                table: "ColaboradorProdutividade");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorProdutividade_SistemaProdutividade_SistemaProdutividadeId",
                table: "ColaboradorProdutividade");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Colaborador_ColaboradorId",
                table: "Tarefas");

            migrationBuilder.DropTable(
                name: "ColaboradorProjetoSprint");

            migrationBuilder.DropTable(
                name: "ProjetoSprintDesign");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Cargo_CargoId",
                table: "Colaborador",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "CargoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorProdutividade_Colaborador_ColaboradorId",
                table: "ColaboradorProdutividade",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorProdutividade_SistemaProdutividade_SistemaProdutividadeId",
                table: "ColaboradorProdutividade",
                column: "SistemaProdutividadeId",
                principalTable: "SistemaProdutividade",
                principalColumn: "SistemaProdutividadeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Colaborador_ColaboradorId",
                table: "Tarefas",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
