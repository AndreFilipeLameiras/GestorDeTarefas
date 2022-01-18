using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Migrations
{
    public partial class pedidoV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataPedido",
                table: "PedidoCliente",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRealizarPedido",
                table: "PedidoCliente",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataResposta",
                table: "PedidoCliente",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProjetoSprintDesignID",
                table: "PedidoCliente",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SistemaProdutividadeId",
                table: "PedidoCliente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCliente_ProjetoSprintDesignID",
                table: "PedidoCliente",
                column: "ProjetoSprintDesignID");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCliente_SistemaProdutividadeId",
                table: "PedidoCliente",
                column: "SistemaProdutividadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoCliente_ProjetoSprintDesign_ProjetoSprintDesignID",
                table: "PedidoCliente",
                column: "ProjetoSprintDesignID",
                principalTable: "ProjetoSprintDesign",
                principalColumn: "ProjetoSprintDesignID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoCliente_SistemaProdutividade_SistemaProdutividadeId",
                table: "PedidoCliente",
                column: "SistemaProdutividadeId",
                principalTable: "SistemaProdutividade",
                principalColumn: "SistemaProdutividadeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoCliente_ProjetoSprintDesign_ProjetoSprintDesignID",
                table: "PedidoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoCliente_SistemaProdutividade_SistemaProdutividadeId",
                table: "PedidoCliente");

            migrationBuilder.DropIndex(
                name: "IX_PedidoCliente_ProjetoSprintDesignID",
                table: "PedidoCliente");

            migrationBuilder.DropIndex(
                name: "IX_PedidoCliente_SistemaProdutividadeId",
                table: "PedidoCliente");

            migrationBuilder.DropColumn(
                name: "DataPedido",
                table: "PedidoCliente");

            migrationBuilder.DropColumn(
                name: "DataRealizarPedido",
                table: "PedidoCliente");

            migrationBuilder.DropColumn(
                name: "DataResposta",
                table: "PedidoCliente");

            migrationBuilder.DropColumn(
                name: "ProjetoSprintDesignID",
                table: "PedidoCliente");

            migrationBuilder.DropColumn(
                name: "SistemaProdutividadeId",
                table: "PedidoCliente");
        }
    }
}
