using GestorDeTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.ViewModels
{
    public class MostrarIdiomaListViewModel
    {
        public IEnumerable<Colaborador> Colaborador { get; set; }

        public IEnumerable<ColaboradorIdioma> ColaboradorIdioma { get; set; }
    }
}
