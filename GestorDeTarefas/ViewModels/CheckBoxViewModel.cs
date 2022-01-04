using GestorDeTarefas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.ViewModels
{
    public class CheckBoxViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataFim { get; set; }

        public ColaboradorProjetoSprint ColaboradorProjetoSprintss { get; set; }

        public ColaboradorProdutividade ColaboradorProjetoProd { get; set; }
    }
}
