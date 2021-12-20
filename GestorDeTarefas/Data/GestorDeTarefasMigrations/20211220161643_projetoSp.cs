using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Data.GestorDeTarefasMigrations
{
    public partial class projetoSp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDefinitivaFim",
                table: "ProjetoSprintDesign",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDefinitivaInicio",
                table: "ProjetoSprintDesign",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPrevistaFim",
                table: "ProjetoSprintDesign",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPrevistaInicio",
                table: "ProjetoSprintDesign",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDefinitivaFim",
                table: "ProjetoSprintDesign");

            migrationBuilder.DropColumn(
                name: "DataDefinitivaInicio",
                table: "ProjetoSprintDesign");

            migrationBuilder.DropColumn(
                name: "DataPrevistaFim",
                table: "ProjetoSprintDesign");

            migrationBuilder.DropColumn(
                name: "DataPrevistaInicio",
                table: "ProjetoSprintDesign");
        }
    }
}
