using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Models
{
    public class ProjetoSprintDesign
    {
        [Key]
        public int ID_P_Design { get; set; }

        [Display(Name = "Nome do projeto")]
        [Required(ErrorMessage = "Por favor, insira o nome do projeto")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O projeto deve ter entre 3 e 60 caracteres")]
        public string NomeProjeto { get; set; }

       public ICollection<ColaboradorProjetoSprint> ProjetoSprintColaboradores { get; set; }


    }
}
