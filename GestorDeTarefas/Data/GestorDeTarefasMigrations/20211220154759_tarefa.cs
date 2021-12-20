using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Data.GestorDeTarefasMigrations
{
    public partial class tarefa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "Tarefas",
                newName: "DataPrevistaInicio");

            migrationBuilder.RenameColumn(
                name: "DataFim",
                table: "Tarefas",
                newName: "DataPrevistaFim");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDefinitivaFim",
                table: "Tarefas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDefinitivaInicio",
                table: "Tarefas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ColaboradorIdioma",
                columns: table => new
                {
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    IdiomaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradorIdioma", x => new { x.ColaboradorId, x.IdiomaId });
                    table.ForeignKey(
                        name: "FK_ColaboradorIdioma_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "ColaboradorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ColaboradorIdioma_Idioma_IdiomaId",
                        column: x => x.IdiomaId,
                        principalTable: "Idioma",
                        principalColumn: "IdiomaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorIdioma_IdiomaId",
                table: "ColaboradorIdioma",
                column: "IdiomaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColaboradorIdioma");

            migrationBuilder.DropColumn(
                name: "DataDefinitivaFim",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "DataDefinitivaInicio",
                table: "Tarefas");

            migrationBuilder.RenameColumn(
                name: "DataPrevistaInicio",
                table: "Tarefas",
                newName: "DataInicio");

            migrationBuilder.RenameColumn(
                name: "DataPrevistaFim",
                table: "Tarefas",
                newName: "DataFim");
        }
    }
}
