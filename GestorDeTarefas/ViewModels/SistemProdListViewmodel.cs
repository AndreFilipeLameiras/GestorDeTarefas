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

        public int ID_SistemaProdutividade { get; set; }
        public string NomeProjeto { get; set; }
        public List<CheckBoxViewModel>Colaboradores { get; set; }
    }
}
