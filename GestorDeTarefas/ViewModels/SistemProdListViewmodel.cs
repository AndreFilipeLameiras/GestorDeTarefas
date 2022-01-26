using GestorDeTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.ViewModels
{
    public class SistemProdListViewmodel
    {
        public IEnumerable<SistemaProdutividade> ProjetoProdutividade { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string NomeSearched { get; set; }

        public string ClienteSearched { get; set; }

        public string EstadoSearched { get; set; }

        public int SistemaProdutividadeId { get; set; }
        public string NomeProjeto { get; set; }
        public List<CheckBoxViewModelProdutividade> Colaboradores { get; set; }

        public List<Tarefas> Tarefas { get; set; }
    }
}
