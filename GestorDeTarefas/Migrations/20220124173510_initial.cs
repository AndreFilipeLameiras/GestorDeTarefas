using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorDeTarefas.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Cargo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.CargoId);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    CidadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.CidadeId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    ContactoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Assunto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Verificado = table.Column<bool>(type: "bit", nullable: false),
                    Resposta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.ContactoId);
                });

            migrationBuilder.CreateTable(
                name: "Idioma",
                columns: table => new
                {
                    IdiomaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeIdioma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idioma", x => x.IdiomaId);
                });

            migrationBuilder.CreateTable(
                name: "SistemaProdutividade",
                columns: table => new
                {
                    SistemaProdutividadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProjeto = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DataPrevistaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDefinitivaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPrevistaFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDefinitivaFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoProjeto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PrioridadeProjeto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaProdutividade", x => x.SistemaProdutividadeId);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    ColaboradorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.ColaboradorId);
                    table.ForeignKey(
                        name: "FK_Colaborador_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "CargoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ColaboradorIdioma",
                columns: table => new
                {
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    IdiomaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradorIdioma", x => new { x.ColaboradorId, x.IdiomaId });
                    table.ForeignKey(
                        name: "FK_ColaboradorIdioma_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "ColaboradorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ColaboradorIdioma_Idioma_IdiomaId",
                        column: x => x.IdiomaId,
                        principalTable: "Idioma",
                        principalColumn: "IdiomaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ColaboradorProdutividade",
                columns: table => new
                {
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    SistemaProdutividadeId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradorProdutividade", x => new { x.ColaboradorId, x.SistemaProdutividadeId });
                    table.ForeignKey(
                        name: "FK_ColaboradorProdutividade_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "ColaboradorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ColaboradorProdutividade_SistemaProdutividade_SistemaProdutividadeId",
                        column: x => x.SistemaProdutividadeId,
                        principalTable: "SistemaProdutividade",
                        principalColumn: "SistemaProdutividadeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjetoSprintDesign",
                columns: table => new
                {
                    ProjetoSprintDesignID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProjeto = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DataPrevistaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDefinitivaInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataPrevistaFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDefinitivaFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoProjeto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ImagemProjeto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoSprintDesign", x => x.ProjetoSprintDesignID);
                    table.ForeignKey(
                        name: "FK_ProjetoSprintDesign_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjetoSprintDesign_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "ColaboradorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ColaboradorProjetoSprint",
                columns: table => new
                {
                    ProjetoSprintDesignID = table.Column<int>(type: "int", nullable: false),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradorProjetoSprint", x => new { x.ProjetoSprintDesignID, x.ColaboradorId });
                    table.ForeignKey(
                        name: "FK_ColaboradorProjetoSprint_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "ColaboradorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ColaboradorProjetoSprint_ProjetoSprintDesign_ProjetoSprintDesignID",
                        column: x => x.ProjetoSprintDesignID,
                        principalTable: "ProjetoSprintDesign",
                        principalColumn: "ProjetoSprintDesignID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidoCliente",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mensagem = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Resposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataRealizarPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataResposta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjetoSprintDesignID = table.Column<int>(type: "int", nullable: true),
                    SistemaProdutividadeId = table.Column<int>(type: "int", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoCliente", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PedidoCliente_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoCliente_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "ColaboradorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoCliente_ProjetoSprintDesign_ProjetoSprintDesignID",
                        column: x => x.ProjetoSprintDesignID,
                        principalTable: "ProjetoSprintDesign",
                        principalColumn: "ProjetoSprintDesignID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoCliente_SistemaProdutividade_SistemaProdutividadeId",
                        column: x => x.SistemaProdutividadeId,
                        principalTable: "SistemaProdutividade",
                        principalColumn: "SistemaProdutividadeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DataPrevistaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDefinitivaInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataPrevistaFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDefinitivaFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoTarefa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    ProjetoSprintDesignID = table.Column<int>(type: "int", nullable: true),
                    SistemaProdutividadeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefas_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "ColaboradorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tarefas_ProjetoSprintDesign_ProjetoSprintDesignID",
                        column: x => x.ProjetoSprintDesignID,
                        principalTable: "ProjetoSprintDesign",
                        principalColumn: "ProjetoSprintDesignID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tarefas_SistemaProdutividade_SistemaProdutividadeId",
                        column: x => x.SistemaProdutividadeId,
                        principalTable: "SistemaProdutividade",
                        principalColumn: "SistemaProdutividadeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_CargoId",
                table: "Colaborador",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorIdioma_IdiomaId",
                table: "ColaboradorIdioma",
                column: "IdiomaId");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorProdutividade_SistemaProdutividadeId",
                table: "ColaboradorProdutividade",
                column: "SistemaProdutividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorProjetoSprint_ColaboradorId",
                table: "ColaboradorProjetoSprint",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCliente_ClienteId",
                table: "PedidoCliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCliente_ColaboradorId",
                table: "PedidoCliente",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCliente_ProjetoSprintDesignID",
                table: "PedidoCliente",
                column: "ProjetoSprintDesignID");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCliente_SistemaProdutividadeId",
                table: "PedidoCliente",
                column: "SistemaProdutividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoSprintDesign_ClienteId",
                table: "ProjetoSprintDesign",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoSprintDesign_ColaboradorId",
                table: "ProjetoSprintDesign",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ColaboradorId",
                table: "Tarefas",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjetoSprintDesignID",
                table: "Tarefas",
                column: "ProjetoSprintDesignID");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_SistemaProdutividadeId",
                table: "Tarefas",
                column: "SistemaProdutividadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "ColaboradorIdioma");

            migrationBuilder.DropTable(
                name: "ColaboradorProdutividade");

            migrationBuilder.DropTable(
                name: "ColaboradorProjetoSprint");

            migrationBuilder.DropTable(
                name: "Contacto");

            migrationBuilder.DropTable(
                name: "PedidoCliente");

            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "Idioma");

            migrationBuilder.DropTable(
                name: "ProjetoSprintDesign");

            migrationBuilder.DropTable(
                name: "SistemaProdutividade");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "Cargo");
        }
    }
}
