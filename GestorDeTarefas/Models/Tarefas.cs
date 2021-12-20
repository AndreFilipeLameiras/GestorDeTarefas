using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Models
{
    public class Tarefas
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome da tarefa")]
        [Required(ErrorMessage = "Por favor, insira a tarefa")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "A tarefa deve ter entre 3 e 80 caracteres")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Prevista de Inicio")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Por favor, insira a data prevista de inicio da tarefa")]
        public DateTime DataPrevistaInicio { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Definitiva do Inicio")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Por favor, insira a data definitiva de inicio da tarefa")]
        public DateTime DataDefinitivaInicio { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Prevista do Fim")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Por favor, insira a data prevista do fim da tarefa")]
        public DateTime DataPrevistaFim { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Data Definitiva do Fim")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataDefinitivaFim { get; set; }

       
        [ForeignKey("FK_ColaboradorId")]
        [DisplayName("Colaborador")]
        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }
    }
}
