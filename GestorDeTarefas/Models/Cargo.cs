using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Models
{
    public class Cargo
    {
        public int CargoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome_Cargo { get; set; }
    }
}
