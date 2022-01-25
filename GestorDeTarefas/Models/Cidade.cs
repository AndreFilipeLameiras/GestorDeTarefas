using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Models
{
    public class Cidade
    {
        public int CidadeId { get; set; }

        [Required(ErrorMessage = "Por favor, insira a cidade")]
        [StringLength(50)]
        public string Nome_Cidade { get; set; }

        public ICollection<Cliente> Clientes { get; set; }
    }
}
