using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Models
{
    public class Gestor
    {
        public int GestorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(200)]
        public string Endereço { get; set; }

        [Required]
        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Telemóvel { get; set; }

        public ICollection<PedidoCliente> PedidoCliente { get; set; }

        public ICollection<ProjetoSprintDesign> ProjetoSprintDesign { get; set; }
    }
}
