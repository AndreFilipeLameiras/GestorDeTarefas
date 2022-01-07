using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorSistemaProdutividade_Colaborador_ColaboradorId",
                table: "ColaboradorSistemaProdutividade");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorSistemaProdutividade_SistemaProdutividade_SistemaProdutividadeId",
                table: "ColaboradorSistemaProdutividade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColaboradorSistemaProdutividade",
                table: "ColaboradorSistemaProdutividade");

            migrationBuilder.DropIndex(
                name: "IX_ColaboradorSistemaProdutividade_ColaboradorId",
                table: "ColaboradorSistemaProdutividade");

            migrationBuilder.RenameTable(
                name: "ColaboradorSistemaProdutividade",
                newName: "ColaboradorProdutividade");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColaboradorProdutividade",
                table: "ColaboradorProdutividade",
                columns: new[] { "ColaboradorId", "SistemaProdutividadeId" });

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorProdutividade_SistemaProdutividadeId",
                table: "ColaboradorProdutividade",
                column: "SistemaProdutividadeId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorProdutividade_Colaborador_ColaboradorId",
                table: "ColaboradorProdutividade");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorProdutividade_SistemaProdutividade_SistemaProdutividadeId",
                table: "ColaboradorProdutividade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColaboradorProdutividade",
                table: "ColaboradorProdutividade");

            migrationBuilder.DropIndex(
                name: "IX_ColaboradorProdutividade_SistemaProdutividadeId",
                table: "ColaboradorProdutividade");

            migrationBuilder.RenameTable(
                name: "ColaboradorProdutividade",
                newName: "ColaboradorSistemaProdutividade");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColaboradorSistemaProdutividade",
                table: "ColaboradorSistemaProdutividade",
                columns: new[] { "SistemaProdutividadeId", "ColaboradorId" });

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorSistemaProdutividade_ColaboradorId",
                table: "ColaboradorSistemaProdutividade",
                column: "ColaboradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorSistemaProdutividade_Colaborador_ColaboradorId",
                table: "ColaboradorSistemaProdutividade",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorSistemaProdutividade_SistemaProdutividade_SistemaProdutividadeId",
                table: "ColaboradorSistemaProdutividade",
                column: "SistemaProdutividadeId",
                principalTable: "SistemaProdutividade",
                principalColumn: "SistemaProdutividadeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
