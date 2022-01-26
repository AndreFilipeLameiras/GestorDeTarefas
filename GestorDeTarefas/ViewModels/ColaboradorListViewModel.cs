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

        public string CargoSearched { get; set; }


        public List<CheckBoxViewModelColaboradorIdioma> Idiomas { get; set;}

        public int ColaboradorId { get; set;}

        public string NomeColaborador { get; set;}

        public string Email { get; set; }

        public string Contacto { get; set; }

        public string Cargo { get; set; }
    }
}
