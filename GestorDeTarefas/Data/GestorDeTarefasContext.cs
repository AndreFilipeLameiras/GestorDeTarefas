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


        public DbSet<GestorDeTarefas.Models.Colaborador> Colaborador { get; set; }

        public DbSet<GestorDeTarefas.Models.Tarefas> Tarefas { get; set; }
    }
}
