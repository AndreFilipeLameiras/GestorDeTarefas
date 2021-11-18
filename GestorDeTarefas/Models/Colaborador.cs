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
    }
}
