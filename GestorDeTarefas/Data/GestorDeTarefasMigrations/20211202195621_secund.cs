using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Data.GestorDeTarefasMigrations
{
    public partial class secund : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SistemaProdutividadeId",
                table: "Colaborador",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SistemaProdutividade",
                columns: table => new
                {
                    SistemaProdutividadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    O_que_fazer = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Estamos_a_fazer = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Concluido = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ColaboradorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaProdutividade", x => x.SistemaProdutividadeId);
                    table.ForeignKey(
                        name: "FK_SistemaProdutividade_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "ColaboradorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_SistemaProdutividadeId",
                table: "Colaborador",
                column: "SistemaProdutividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_SistemaProdutividade_ColaboradorId",
                table: "SistemaProdutividade",
                column: "ColaboradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_SistemaProdutividade_SistemaProdutividadeId",
                table: "Colaborador",
                column: "SistemaProdutividadeId",
                principalTable: "SistemaProdutividade",
                principalColumn: "SistemaProdutividadeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_SistemaProdutividade_SistemaProdutividadeId",
                table: "Colaborador");

            migrationBuilder.DropTable(
                name: "SistemaProdutividade");

            migrationBuilder.DropIndex(
                name: "IX_Colaborador_SistemaProdutividadeId",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "SistemaProdutividadeId",
                table: "Colaborador");
        }
    }
}
