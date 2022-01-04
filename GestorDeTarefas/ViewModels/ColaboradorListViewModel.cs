using GestorDeTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.ViewModels
{
    public class ColaboradorListViewModel
    {
        public IEnumerable<Colaborador> Colaboradors { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string NomeSearched { get; set; }

        public List<CheckBoxViewModelColaboradorIdioma> Idiomas { get; set;}

        public int ColaboradorId { get; set;}

        public string NomeColaborador { get; set;}
    }
}
