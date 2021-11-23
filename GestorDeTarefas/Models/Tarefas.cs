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

        [Display(Name = "Data Inicio")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataInicio { get; set; }


        [Display(Name = "Data Fim")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataFim { get; set; }

        [ForeignKey("FK_ColaboradorId")]
        [DisplayName("Colaborador")]
        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }
    }
}
