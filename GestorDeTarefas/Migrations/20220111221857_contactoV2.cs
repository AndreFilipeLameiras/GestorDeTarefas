using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Migrations
{
    public partial class contactoV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Resposta",
                table: "Contacto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Verificado",
                table: "Contacto",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resposta",
                table: "Contacto");

            migrationBuilder.DropColumn(
                name: "Verificado",
                table: "Contacto");
        }
    }
}
