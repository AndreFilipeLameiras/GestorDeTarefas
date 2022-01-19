using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Models
{
    public class PedidoCliente
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Por favor, escreva a mensagem")]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Mensagem deve ter pelo menos 5 caracteres e um máximo de 1000")]
        public string Mensagem { get; set; }

        [Display(Name = "Resposta")]
        public string Resposta { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data para realização do pedido")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataRealizarPedido { get; set; }

        [DataType(DataType.Date)]      
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DataPedido { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DataResposta { get; set; }

        public int? ProjetoSprintDesignID { get; set; }
        public ProjetoSprintDesign ProjetoSprintDesign { get; set; }

        public int? SistemaProdutividadeId { get; set; }
        public SistemaProdutividade SistemaProdutividade { get; set; }


        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }

    }
}
