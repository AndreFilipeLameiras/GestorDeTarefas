using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Models
{
    public class Colaborador
    {
        public int ColaboradorId { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [EmailAddress (ErrorMessage = "Por favor insira um endereço de e-mail válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor insira um contacto válido")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O contacto deve ter entre 9 caracteres")]
        public string Contacto { get; set; }

        /*nova tabela */
        public string Cargo { get; set; }

        public ICollection<Tarefas> Tarefas { get; set; }
    }
}
