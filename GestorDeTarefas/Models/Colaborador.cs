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

        public string Email { get; set; }

        public string Contacto { get; set; }

        public string Cargo { get; set; }

        public ICollection<Tarefas> Tarefas { get; set; }

    }
}
