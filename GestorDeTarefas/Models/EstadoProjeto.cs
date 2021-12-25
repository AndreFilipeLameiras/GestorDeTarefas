using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Models
{
    public class EstadoProjeto
    {
        [Key]
        public int Id_Estado { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Por favor, insira o estado")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "O estado deve ter entre 5 e 20 caracteres")]
        public string NomeEstado { get; set; }
    }
}
