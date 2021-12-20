using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Data.GestorDeTarefasMigrations
{
    public partial class tarefasProjetoS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_P_Design",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjetoSprintID_P_Design",
                table: "Tarefas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjetoSprintID_P_Design",
                table: "Tarefas",
                column: "ProjetoSprintID_P_Design");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_ProjetoSprintDesign_ProjetoSprintID_P_Design",
                table: "Tarefas",
                column: "ProjetoSprintID_P_Design",
                principalTable: "ProjetoSprintDesign",
                principalColumn: "ID_P_Design",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_ProjetoSprintDesign_ProjetoSprintID_P_Design",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_ProjetoSprintID_P_Design",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "ID_P_Design",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "ProjetoSprintID_P_Design",
                table: "Tarefas");
        }
    }
}
