using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Migrations
{
    public partial class clien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Cliente");

            migrationBuilder.AddColumn<string>(
                name: "Telemovel",
                table: "Cliente",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telemovel",
                table: "Cliente");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
