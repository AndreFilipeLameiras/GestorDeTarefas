using GestorDeTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.ViewModels
{
    public class IdiomaListViewModel
    {
        public IEnumerable<Idioma> Idiomas { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string TitleSearched { get; set; }
    }
}
