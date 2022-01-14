using GestorDeTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.ViewModels
{
    public class PedidoClienteListViewModel
    {
        public IEnumerable<PedidoCliente> PedidoCliente { get; set; }

        public int ClienteId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Cidade { get; set; }

        public string Mensagem { get; set; }

        public string Resposta { get; set; }

        public int? GestorId { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string NomeSearched { get; set; }
    }
}
