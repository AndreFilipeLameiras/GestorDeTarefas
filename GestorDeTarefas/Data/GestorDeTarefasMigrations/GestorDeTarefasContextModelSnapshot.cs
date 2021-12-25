﻿// <auto-generated />
using System;
using GestorDeTarefas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestorDeTarefas.Data.GestorDeTarefasMigrations
{
    [DbContext(typeof(GestorDeTarefasContext))]
    partial class GestorDeTarefasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasKey("ColaboradorId", "SistemaProdutividadeId");

                    b.HasIndex("SistemaProdutividadeId");

                    b.ToTable("ColaboradorProdutividade");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.ColaboradorProjetoSprint", b =>
                {
                    b.Property<int>("ID_P_Design")
                        .HasColumnType("int");

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.HasKey("ID_P_Design", "ColaboradorId");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("ColaboradorProjetoSprint");
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

            modelBuilder.Entity("GestorDeTarefas.Models.ProjetoSprintDesign", b =>
                {
                    b.Property<int>("ID_P_Design")
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

                    b.Property<string>("NomeProjeto")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("ID_P_Design");

                    b.ToTable("ProjetoSprintDesign");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.SistemaProdutividade", b =>
                {
                    b.Property<int>("SistemaProdutividadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataDefinitivaFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDefinitivaInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevistaFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrevistaInicio")
                        .HasColumnType("datetime2");

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

                    b.Property<int>("ID_P_Design")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int?>("ProjetoSprintID_P_Design")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.HasIndex("ProjetoSprintID_P_Design");

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
                        .WithMany("ColaboradorProdutividad")
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
                        .HasForeignKey("ID_P_Design")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Colaborador");

                    b.Navigation("ProjetoSprintDesign");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.Tarefas", b =>
                {
                    b.HasOne("GestorDeTarefas.Models.Colaborador", "Colaborador")
                        .WithMany("Tarefas")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestorDeTarefas.Models.ProjetoSprintDesign", "ProjetoSprint")
                        .WithMany("Tarefas")
                        .HasForeignKey("ProjetoSprintID_P_Design");

                    b.Navigation("Colaborador");

                    b.Navigation("ProjetoSprint");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.Cargo", b =>
                {
                    b.Navigation("Colaboradors");
                });

            modelBuilder.Entity("GestorDeTarefas.Models.Colaborador", b =>
                {
                    b.Navigation("ColaboradorIdiomas");

                    b.Navigation("ColaboradorProdutividad");

                    b.Navigation("ColaboradorProjetoSprints");

                    b.Navigation("Tarefas");
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
                });
#pragma warning restore 612, 618
        }
    }
}
