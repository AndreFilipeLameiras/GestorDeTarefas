using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Models
{
    public class Idioma
    {
        public int IdiomaId { get; set; }

        public string NomeIdioma { get; set; }

        public ICollection<ColaboradorIdioma> IdiomaColaboradores { get; set; }

    }
}
