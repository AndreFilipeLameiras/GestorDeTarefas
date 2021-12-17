using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Models
{


    public class Idioma
    {
        [Key]
        public int IdiomaId { get; set; }

       
        [Required(ErrorMessage = "Por favor, insira o nome do Idioma")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O Idioma deve ter entre 3 a 20 caracteres ")]
        public string NomeIdioma { get; set; }

        public ICollection<ColaboradorIdioma> IdiomaColaboradores { get; set; }

    }
}
