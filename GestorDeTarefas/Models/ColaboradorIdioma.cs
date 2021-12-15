using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Models
{
    public class ColaboradorIdioma
    {
        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }


        public int IdiomaId { get; set; }
        public Idioma Idioma { get; set; }


    }
}
