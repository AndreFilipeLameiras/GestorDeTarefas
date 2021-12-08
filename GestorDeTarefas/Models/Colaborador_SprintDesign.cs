using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Models
{
    public class Colaborador_SprintDesign
    {
        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }

        public int ID_P_Design { get; set; }
        public ProjetoSprintDesign ProjetoSprintDesign { get; set; }

        [Display(Name = "Data Inicio")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Por favor, insira a data de inicio do projeto")]
        public DateTime DataInicio { get; set; }


        [Display(Name = "Data Fim")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Por favor, insira a data do fim do projeto")]
        public DateTime DataFim { get; set; }
    }
}
