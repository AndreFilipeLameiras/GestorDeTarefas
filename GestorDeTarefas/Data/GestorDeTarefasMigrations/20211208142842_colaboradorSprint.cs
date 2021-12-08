using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Data.GestorDeTarefasMigrations
{
    public partial class colaboradorSprint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Colaborador_SprintDesign",
                columns: table => new
                {
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    ID_P_Design = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador_SprintDesign", x => new { x.ColaboradorId, x.ID_P_Design });
                    table.ForeignKey(
                        name: "FK_Colaborador_SprintDesign_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "ColaboradorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Colaborador_SprintDesign_ProjetoSprintDesign_ID_P_Design",
                        column: x => x.ID_P_Design,
                        principalTable: "ProjetoSprintDesign",
                        principalColumn: "ID_P_Design",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_SprintDesign_ID_P_Design",
                table: "Colaborador_SprintDesign",
                column: "ID_P_Design");

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
                name: "FK_ColaboradorProdutividade_Colaborador_ColaboradorId",
                table: "ColaboradorProdutividade");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorProdutividade_SistemaProdutividade_SistemaProdutividadeId",
                table: "ColaboradorProdutividade");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Colaborador_ColaboradorId",
                table: "Tarefas");

            migrationBuilder.DropTable(
                name: "Colaborador_SprintDesign");

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
