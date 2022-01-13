using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "ProjetoSprintDesign",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GestorId",
                table: "ProjetoSprintDesign",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoSprintDesign_ClienteId",
                table: "ProjetoSprintDesign",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoSprintDesign_GestorId",
                table: "ProjetoSprintDesign",
                column: "GestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjetoSprintDesign_Cliente_ClienteId",
                table: "ProjetoSprintDesign",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjetoSprintDesign_Gestor_GestorId",
                table: "ProjetoSprintDesign",
                column: "GestorId",
                principalTable: "Gestor",
                principalColumn: "GestorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjetoSprintDesign_Cliente_ClienteId",
                table: "ProjetoSprintDesign");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjetoSprintDesign_Gestor_GestorId",
                table: "ProjetoSprintDesign");

            migrationBuilder.DropIndex(
                name: "IX_ProjetoSprintDesign_ClienteId",
                table: "ProjetoSprintDesign");

            migrationBuilder.DropIndex(
                name: "IX_ProjetoSprintDesign_GestorId",
                table: "ProjetoSprintDesign");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "ProjetoSprintDesign");

            migrationBuilder.DropColumn(
                name: "GestorId",
                table: "ProjetoSprintDesign");
        }
    }
}
