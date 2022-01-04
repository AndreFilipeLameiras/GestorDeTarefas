using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDefinitivaFim",
                table: "SistemaProdutividade",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "EstadoProjeto",
                table: "SistemaProdutividade",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFim",
                table: "ColaboradorSistemaProdutividade",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicio",
                table: "ColaboradorSistemaProdutividade",
                type: "datetime2",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "EstadoProjeto",
                table: "SistemaProdutividade");

            migrationBuilder.DropColumn(
                name: "DataFim",
                table: "ColaboradorSistemaProdutividade");

            migrationBuilder.DropColumn(
                name: "DataInicio",
                table: "ColaboradorSistemaProdutividade");

            migrationBuilder.RenameTable(
                name: "ColaboradorSistemaProdutividade",
                newName: "ColaboradorProdutividade");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDefinitivaFim",
                table: "SistemaProdutividade",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
    }
}
