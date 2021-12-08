using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Data.GestorDeTarefasMigrations
{
    public partial class P_Sprint_Design : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjetoSprintDesign",
                columns: table => new
                {
                    ID_P_Design = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProjeto = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoSprintDesign", x => x.ID_P_Design);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjetoSprintDesign");
        }
    }
}
