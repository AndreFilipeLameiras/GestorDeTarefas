using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Migrations
{
    public partial class nova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoCliente_Gestor_GestorId",
                table: "PedidoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjetoSprintDesign_Gestor_GestorId",
                table: "ProjetoSprintDesign");

            migrationBuilder.DropTable(
                name: "Gestor");

            migrationBuilder.DropIndex(
                name: "IX_PedidoCliente_GestorId",
                table: "PedidoCliente");

            migrationBuilder.DropColumn(
                name: "GestorId",
                table: "PedidoCliente");

            migrationBuilder.RenameColumn(
                name: "GestorId",
                table: "ProjetoSprintDesign",
                newName: "ColaboradorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjetoSprintDesign_GestorId",
                table: "ProjetoSprintDesign",
                newName: "IX_ProjetoSprintDesign_ColaboradorId");

            migrationBuilder.AddColumn<int>(
                name: "ColaboradorId",
                table: "PedidoCliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCliente_ColaboradorId",
                table: "PedidoCliente",
                column: "ColaboradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoCliente_Colaborador_ColaboradorId",
                table: "PedidoCliente",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjetoSprintDesign_Colaborador_ColaboradorId",
                table: "ProjetoSprintDesign",
                column: "ColaboradorId",
                principalTable: "Colaborador",
                principalColumn: "ColaboradorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoCliente_Colaborador_ColaboradorId",
                table: "PedidoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjetoSprintDesign_Colaborador_ColaboradorId",
                table: "ProjetoSprintDesign");

            migrationBuilder.DropIndex(
                name: "IX_PedidoCliente_ColaboradorId",
                table: "PedidoCliente");

            migrationBuilder.DropColumn(
                name: "ColaboradorId",
                table: "PedidoCliente");

            migrationBuilder.RenameColumn(
                name: "ColaboradorId",
                table: "ProjetoSprintDesign",
                newName: "GestorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjetoSprintDesign_ColaboradorId",
                table: "ProjetoSprintDesign",
                newName: "IX_ProjetoSprintDesign_GestorId");

            migrationBuilder.AddColumn<int>(
                name: "GestorId",
                table: "PedidoCliente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gestor",
                columns: table => new
                {
                    GestorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Endereço = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telemóvel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gestor", x => x.GestorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCliente_GestorId",
                table: "PedidoCliente",
                column: "GestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoCliente_Gestor_GestorId",
                table: "PedidoCliente",
                column: "GestorId",
                principalTable: "Gestor",
                principalColumn: "GestorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjetoSprintDesign_Gestor_GestorId",
                table: "ProjetoSprintDesign",
                column: "GestorId",
                principalTable: "Gestor",
                principalColumn: "GestorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
