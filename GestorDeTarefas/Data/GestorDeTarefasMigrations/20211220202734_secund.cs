using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Data.GestorDeTarefasMigrations
{
    public partial class secund : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concluido",
                table: "SistemaProdutividade");

            migrationBuilder.DropColumn(
                name: "Estamos_a_fazer",
                table: "SistemaProdutividade");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "SistemaProdutividade");

            migrationBuilder.DropColumn(
                name: "O_que_fazer",
                table: "SistemaProdutividade");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDefinitivaFim",
                table: "SistemaProdutividade",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDefinitivaInicio",
                table: "SistemaProdutividade",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPrevistaFim",
                table: "SistemaProdutividade",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPrevistaInicio",
                table: "SistemaProdutividade",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NomeProjeto",
                table: "SistemaProdutividade",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDefinitivaFim",
                table: "SistemaProdutividade");

            migrationBuilder.DropColumn(
                name: "DataDefinitivaInicio",
                table: "SistemaProdutividade");

            migrationBuilder.DropColumn(
                name: "DataPrevistaFim",
                table: "SistemaProdutividade");

            migrationBuilder.DropColumn(
                name: "DataPrevistaInicio",
                table: "SistemaProdutividade");

            migrationBuilder.DropColumn(
                name: "NomeProjeto",
                table: "SistemaProdutividade");

            migrationBuilder.AddColumn<string>(
                name: "Concluido",
                table: "SistemaProdutividade",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estamos_a_fazer",
                table: "SistemaProdutividade",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "SistemaProdutividade",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "O_que_fazer",
                table: "SistemaProdutividade",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }
    }
}
