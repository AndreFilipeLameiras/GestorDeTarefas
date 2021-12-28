using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Migrations
{
    public partial class tarefasv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_EstadoProjeto_EstadoProjetoId_Estado",
                table: "Tarefas");

            migrationBuilder.DropTable(
                name: "EstadoProjeto");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_EstadoProjetoId_Estado",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "EstadoProjetoId_Estado",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "Id_Estado",
                table: "Tarefas");

            migrationBuilder.AddColumn<string>(
                name: "EstadoTarefa",
                table: "Tarefas",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoTarefa",
                table: "Tarefas");

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

            migrationBuilder.CreateTable(
                name: "EstadoProjeto",
                columns: table => new
                {
                    Id_Estado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEstado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoProjeto", x => x.Id_Estado);
                });

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
    }
}
