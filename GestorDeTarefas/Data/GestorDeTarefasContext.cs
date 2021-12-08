using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestorDeTarefas.Models;

namespace GestorDeTarefas.Data
{
    public class GestorDeTarefasContext : DbContext
    {
        public GestorDeTarefasContext (DbContextOptions<GestorDeTarefasContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ColaboradorProdutividade>()
                .HasKey(bc => new { bc.ColaboradorId, bc.SistemaProdutividadeId });

            modelBuilder.Entity<ColaboradorProdutividade>()
                .HasOne(bc => bc.Colaborador)
                .WithMany(b => b.ColaboradorProdutividad)
                .HasForeignKey(bc => bc.ColaboradorId);

            modelBuilder.Entity<ColaboradorProdutividade>()
                .HasOne(bc => bc.SistemaProdutividade)
                .WithMany(c => c.ProdutividadeColaborador)
                .HasForeignKey(bc => bc.SistemaProdutividadeId);

            /////////////ColaboradorProjetoSprintDesign/////////////////////
            
            modelBuilder.Entity<Colaborador_SprintDesign>()//adicionar chave primaria composta
               .HasKey(bc => new { bc.ColaboradorId, bc.ID_P_Design });       

            /////////////ColaboradorProjetoDesign/////////////////////

        }



        public DbSet<GestorDeTarefas.Models.Colaborador> Colaborador { get; set; }

        public DbSet<GestorDeTarefas.Models.Tarefas> Tarefas { get; set; }

        public DbSet<GestorDeTarefas.Models.SistemaProdutividade> SistemaProdutividade { get; set; }

        public DbSet<GestorDeTarefas.Models.ProjetoSprintDesign> ProjetoSprintDesign { get; set; }
    }
}
