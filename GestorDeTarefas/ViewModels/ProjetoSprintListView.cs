using GestorDeTarefas.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.ViewModels
{
    public class ProjetoSprintListView
    {
        public IEnumerable<ProjetoSprint> ProjetoSprints { get; set; } 
        public PagingInfo PagingInfo { get; set; } 
    }
}
