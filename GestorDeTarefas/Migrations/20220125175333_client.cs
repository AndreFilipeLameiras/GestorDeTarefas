using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Migrations
{
    public partial class client : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "CidadeId",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CidadeId",
                table: "Cliente",
                column: "CidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Cidade_CidadeId",
                table: "Cliente",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "CidadeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Cidade_CidadeId",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_CidadeId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "CidadeId",
                table: "Cliente");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Cliente",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
