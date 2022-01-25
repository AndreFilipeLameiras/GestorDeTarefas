using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(256)]
        public string Morada { get; set; }

        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }

        [Required]
        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, insira o contacto")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O contacto deve ter 9 caracteres")]
        [RegularExpression(@"(9\d{8})", ErrorMessage = "Numero invalido.")]
        public string Telemovel { get; set; }

        public ICollection<PedidoCliente> PedidoCliente { get; set; }

        public ICollection<ProjetoSprintDesign> ProjetoSprintDesign { get; set; }
    }
}
