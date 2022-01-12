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
                .WithMany(b => b.ColaboradorProdutividade)
                .HasForeignKey(bc => bc.ColaboradorId);

            modelBuilder.Entity<ColaboradorProdutividade>()
                .HasOne(bc => bc.SistemaProdutividade)
                .WithMany(c => c.ProdutividadeColaborador)
                .HasForeignKey(bc => bc.SistemaProdutividadeId);

            ////////////////Idioma Colaborador//////////////////
            modelBuilder.Entity<ColaboradorIdioma>()
               .HasKey(bc => new { bc.ColaboradorId, bc.IdiomaId });

            modelBuilder.Entity<ColaboradorIdioma>()
                .HasOne(bc => bc.Colaborador)
                .WithMany(b => b.ColaboradorIdiomas)
                .HasForeignKey(bc => bc.ColaboradorId);

            modelBuilder.Entity<ColaboradorIdioma>()
                .HasOne(bc => bc.Idioma)
                .WithMany(c => c.IdiomaColaboradores)
                .HasForeignKey(bc => bc.IdiomaId);

            //////////Fim Idioma Colaborador//////////////


            ////////////ProjetoSprint Colaborador////////////

            modelBuilder.Entity<ColaboradorProjetoSprint>()
                .HasKey(pc => new { pc.ProjetoSprintDesignID, pc.ColaboradorId });


            modelBuilder.Entity<ColaboradorProjetoSprint>()
               .HasOne(bc => bc.ProjetoSprintDesign)
               .WithMany(b => b.ProjetoSprintColaboradores)
               .HasForeignKey(bc => bc.ProjetoSprintDesignID);

            modelBuilder.Entity<ColaboradorProjetoSprint>()
                .HasOne(bc => bc.Colaborador)
                .WithMany(c => c.ColaboradorProjetoSprints)
                .HasForeignKey(bc => bc.ColaboradorId);

            var foreignKeysWithCascadeDelete = modelBuilder.Model.GetEntityTypes()
               .SelectMany(t => t.GetForeignKeys())
               .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in foreignKeysWithCascadeDelete)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }


            //////////////////Fim ProjetoSprint Colaborador///////////// 





            ////////////SistemaProdutividade Colaborador////////////

            //modelBuilder.Entity<ColaboradorProdutividade>()
            //    .HasKey(pc => new { pc.SistemaProdutividadeId, pc.ColaboradorId });          


            //modelBuilder.Entity<ColaboradorProjetoSprint>()
            //   .HasOne(bc => bc.ProjetoSprintDesign)
            //   .WithMany(b => b.ProjetoSprintColaboradores)
            //   .HasForeignKey(bc => bc.ProjetoSprintDesignID);

            //modelBuilder.Entity<ColaboradorProjetoSprint>()
            //    .HasOne(bc => bc.Colaborador)
            //    .WithMany(c => c.ColaboradorProjetoSprints)
            //    .HasForeignKey(bc => bc.ColaboradorId);

            //////////////////Fim SistemProdutividade Colaborador/////////////
        }



        public DbSet<GestorDeTarefas.Models.Colaborador> Colaborador { get; set; }

        public DbSet<GestorDeTarefas.Models.Tarefas> Tarefas { get; set; }

        public DbSet<GestorDeTarefas.Models.SistemaProdutividade> SistemaProdutividade { get; set; }

        public DbSet<GestorDeTarefas.Models.ColaboradorProdutividade> ColaboradorProdutividade { get; set; }

        public DbSet<GestorDeTarefas.Models.Cargo> Cargo { get; set; }

        public DbSet<GestorDeTarefas.Models.ColaboradorProjetoSprint> ColaboradorProjetoSprint { get; set; }

        public DbSet<GestorDeTarefas.Models.ProjetoSprintDesign> ProjetoSprintDesign { get; set; }

        public DbSet<GestorDeTarefas.Models.Idioma> Idioma { get; set; }

        public DbSet<GestorDeTarefas.Models.ColaboradorIdioma> ColaboradorIdioma { get; set; }
        public DbSet<GestorDeTarefas.Models.Contacto> Contacto { get; set; }

        public DbSet<GestorDeTarefas.Models.Cliente> Cliente { get; set; }
    }
}
