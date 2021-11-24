using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Data.QuadrosMigration
{
    public partial class Colaboradores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColaboradorId",
                table: "Quadros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    ColaboradorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.ColaboradorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quadros_ColaboradorId",
                table: "Quadros",
                column: "ColaboradorId");

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

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropIndex(
                name: "IX_Quadros_ColaboradorId",
                table: "Quadros");

            migrationBuilder.DropColumn(
                name: "ColaboradorId",
                table: "Quadros");
        }
    }
}
