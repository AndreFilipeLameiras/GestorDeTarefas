using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Models
{
    public class ColaboradorProdutividade
    {
        public int ColaboradorId { get; set; }

        public Colaborador Colaborador { get; set; }

        public int SistemaProdutividadeId { get; set; }


        public SistemaProdutividade SistemaProdutividade { get; set; }

    }
}
