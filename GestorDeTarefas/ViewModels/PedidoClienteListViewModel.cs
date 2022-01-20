using GestorDeTarefas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.ViewModels
{
    public class PedidoClienteListViewModel
    {
        public IEnumerable<PedidoCliente> PedidoCliente { get; set; }

        public IEnumerable<SelectListItem> ProjetoSprintDesign { get; set; }
        public IEnumerable<SelectListItem> Colaborador { get; set; }
        public IEnumerable<SelectListItem> Cliente { get; set; }
        public IEnumerable<SelectListItem> SistemaProdutividade { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data para realização do pedido")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataRealizarPedido { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data do pedido")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataPedido { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data da resposta")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataResposta { get; set; }

        public int ProjetoSprintDesignID { get; set; }

        public int PedidoID { get; set; }

        public int? SistemaProdutividadeId { get; set; }
        public int ClienteId { get; set; }

        
        public string Nome { get; set; }

        public string NomeProjeto { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Cidade { get; set; }

        public string Mensagem { get; set; }

        public string Resposta { get; set; }

        public int ColaboradorId { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string NomeSearched { get; set; }
    }
}
