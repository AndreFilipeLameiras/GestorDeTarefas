using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Migrations
{
    public partial class tarefasV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoProjetoId_Estado",
                table: "Tarefas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_Estado",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_EstadoProjetoId_Estado",
                table: "Tarefas",
                column: "EstadoProjetoId_Estado");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_EstadoProjeto_EstadoProjetoId_Estado",
                table: "Tarefas",
                column: "EstadoProjetoId_Estado",
                principalTable: "EstadoProjeto",
                principalColumn: "Id_Estado",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_EstadoProjeto_EstadoProjetoId_Estado",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_EstadoProjetoId_Estado",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "EstadoProjetoId_Estado",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "Id_Estado",
                table: "Tarefas");
        }
    }
}
