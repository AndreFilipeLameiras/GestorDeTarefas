using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Data.QuadrosMigration
{
    public partial class sete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quadros_Colaborador_ColaboradorId",
                table: "Quadros");

            migrationBuilder.AlterColumn<int>(
                name: "ColaboradorId",
                table: "Quadros",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Quadros_Colaborador_ColaboradorId",
                table: "Quadros",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quadros_Colaborador_ColaboradorId",
                table: "Quadros");

            migrationBuilder.AlterColumn<int>(
                name: "ColaboradorId",
                table: "Quadros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Quadros_Colaborador_ColaboradorId",
                table: "Quadros",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
