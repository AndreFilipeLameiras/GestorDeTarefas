﻿// <auto-generated />
using System;
using GestorDeTarefas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestorDeTarefas.Migrations
{
    [DbContext(typeof(GestorDeTarefasContext))]
    [Migration("20220114115230_cliente")]
    partial class cliente
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GestorDeTarefas.Models.Cargo", b =>
                {
                    b.Property<int>("CargoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome_Cargo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CargoId");

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.Colaborador", b =>
                {
                    b.Property<int>("ColaboradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("ColaboradorId");

                    b.HasIndex("CargoId");

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.ColaboradorIdioma", b =>
                {
                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<int>("IdiomaId")
                        .HasColumnType("int");

                    b.HasKey("ColaboradorId", "IdiomaId");

                    b.HasIndex("IdiomaId");

                    b.ToTable("ColaboradorIdioma");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.ColaboradorProdutividade", b =>
                {
                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<int>("SistemaProdutividadeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("datetime2");

                    b.HasKey("ColaboradorId", "SistemaProdutividadeId");

                    b.HasIndex("SistemaProdutividadeId");

                    b.ToTable("ColaboradorProdutividade");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.ColaboradorProjetoSprint", b =>
                {
                    b.Property<int>("ProjetoSprintDesignID")
                        .HasColumnType("int");

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjetoSprintDesignID", "ColaboradorId");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("ColaboradorProjetoSprint");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.Contacto", b =>
                {
                    b.Property<int>("ContactoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Assunto")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Resposta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("Verificado")
                        .HasColumnType("bit");

                    b.HasKey("ContactoId");

                    b.ToTable("Contacto");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.Gestor", b =>
                {
                    b.Property<int>("GestorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Endereço")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telemóvel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GestorId");

                    b.ToTable("Gestor");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.Idioma", b =>
                {
                    b.Property<int>("IdiomaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeIdioma")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdiomaId");

                    b.ToTable("Idioma");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.PedidoCliente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("GestorId")
                        .HasColumnType("int");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Resposta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ClienteId");

                    b.HasIndex("GestorId");

                    b.ToTable("PedidoCliente");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.ProjetoSprintDesign", b =>
                {
                    b.Property<int>("ProjetoSprintDesignID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataDefinitivaFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDefinitivaInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevistaFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevistaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("EstadoProjeto")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("GestorId")
                        .HasColumnType("int");

                    b.Property<string>("ImagemProjeto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeProjeto")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("ProjetoSprintDesignID");

                    b.HasIndex("ClienteId");

                    b.HasIndex("GestorId");

                    b.ToTable("ProjetoSprintDesign");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.SistemaProdutividade", b =>
                {
                    b.Property<int>("SistemaProdutividadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataDefinitivaFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDefinitivaInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevistaFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevistaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("EstadoProjeto")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NomeProjeto")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("SistemaProdutividadeId");

                    b.ToTable("SistemaProdutividade");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.Tarefas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataDefinitivaFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDefinitivaInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevistaFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevistaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("EstadoTarefa")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int?>("ProjetoSprintDesignID")
                        .HasColumnType("int");

                    b.Property<int?>("SistemaProdutividadeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.HasIndex("ProjetoSprintDesignID");

                    b.HasIndex("SistemaProdutividadeId");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.Colaborador", b =>
                {
                    b.HasOne("GestorDeTarefas.Models.Cargo", "Cargo")
                        .WithMany("Colaboradors")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.ColaboradorIdioma", b =>
                {
                    b.HasOne("GestorDeTarefas.Models.Colaborador", "Colaborador")
                        .WithMany("ColaboradorIdiomas")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestorDeTarefas.Models.Idioma", "Idioma")
                        .WithMany("IdiomaColaboradores")
                        .HasForeignKey("IdiomaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Colaborador");

                    b.Navigation("Idioma");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.ColaboradorProdutividade", b =>
                {
                    b.HasOne("GestorDeTarefas.Models.Colaborador", "Colaborador")
                        .WithMany("ColaboradorProdutividade")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestorDeTarefas.Models.SistemaProdutividade", "SistemaProdutividade")
                        .WithMany("ProdutividadeColaborador")
                        .HasForeignKey("SistemaProdutividadeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Colaborador");

                    b.Navigation("SistemaProdutividade");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.ColaboradorProjetoSprint", b =>
                {
                    b.HasOne("GestorDeTarefas.Models.Colaborador", "Colaborador")
                        .WithMany("ColaboradorProjetoSprints")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestorDeTarefas.Models.ProjetoSprintDesign", "ProjetoSprintDesign")
                        .WithMany("ProjetoSprintColaboradores")
                        .HasForeignKey("ProjetoSprintDesignID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Colaborador");

                    b.Navigation("ProjetoSprintDesign");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.PedidoCliente", b =>
                {
                    b.HasOne("GestorDeTarefas.Models.Cliente", "Cliente")
                        .WithMany("PedidoCliente")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestorDeTarefas.Models.Gestor", "Gestor")
                        .WithMany("PedidoCliente")
                        .HasForeignKey("GestorId");

                    b.Navigation("Cliente");

                    b.Navigation("Gestor");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.ProjetoSprintDesign", b =>
                {
                    b.HasOne("GestorDeTarefas.Models.Cliente", "Cliente")
                        .WithMany("ProjetoSprintDesign")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestorDeTarefas.Models.Gestor", "Gestor")
                        .WithMany("ProjetoSprintDesign")
                        .HasForeignKey("GestorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Gestor");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.Tarefas", b =>
                {
                    b.HasOne("GestorDeTarefas.Models.Colaborador", "Colaborador")
                        .WithMany("Tarefas")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestorDeTarefas.Models.ProjetoSprintDesign", "ProjetoSprintDesign")
                        .WithMany("Tarefas")
                        .HasForeignKey("ProjetoSprintDesignID");

                    b.HasOne("GestorDeTarefas.Models.SistemaProdutividade", "SistemaProdutividade")
                        .WithMany("Tarefas")
                        .HasForeignKey("SistemaProdutividadeId");

                    b.Navigation("Colaborador");

                    b.Navigation("ProjetoSprintDesign");

                    b.Navigation("SistemaProdutividade");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.Cargo", b =>
                {
                    b.Navigation("Colaboradors");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.Cliente", b =>
                {
                    b.Navigation("PedidoCliente");

                    b.Navigation("ProjetoSprintDesign");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.Colaborador", b =>
                {
                    b.Navigation("ColaboradorIdiomas");

                    b.Navigation("ColaboradorProdutividade");

                    b.Navigation("ColaboradorProjetoSprints");

                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.Gestor", b =>
                {
                    b.Navigation("PedidoCliente");

                    b.Navigation("ProjetoSprintDesign");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.Idioma", b =>
                {
                    b.Navigation("IdiomaColaboradores");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.ProjetoSprintDesign", b =>
                {
                    b.Navigation("ProjetoSprintColaboradores");

                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.SistemaProdutividade", b =>
                {
                    b.Navigation("ProdutividadeColaborador");

                    b.Navigation("Tarefas");
                });
#pragma warning restore 612, 618
        }
    }
}
