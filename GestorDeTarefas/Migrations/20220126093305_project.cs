using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Migrations
{
    public partial class project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "SistemaProdutividade",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ColaboradorId",
                table: "SistemaProdutividade",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SistemaProdutividade_ClienteId",
                table: "SistemaProdutividade",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_SistemaProdutividade_ColaboradorId",
                table: "SistemaProdutividade",
                column: "ColaboradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_SistemaProdutividade_Cliente_ClienteId",
                table: "SistemaProdutividade",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SistemaProdutividade_Colaborador_ColaboradorId",
                table: "SistemaProdutividade",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SistemaProdutividade_Cliente_ClienteId",
                table: "SistemaProdutividade");

            migrationBuilder.DropForeignKey(
                name: "FK_SistemaProdutividade_Colaborador_ColaboradorId",
                table: "SistemaProdutividade");

            migrationBuilder.DropIndex(
                name: "IX_SistemaProdutividade_ClienteId",
                table: "SistemaProdutividade");

            migrationBuilder.DropIndex(
                name: "IX_SistemaProdutividade_ColaboradorId",
                table: "SistemaProdutividade");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "SistemaProdutividade");

            migrationBuilder.DropColumn(
                name: "ColaboradorId",
                table: "SistemaProdutividade");
        }
    }
}
