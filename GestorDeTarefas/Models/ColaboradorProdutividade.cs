using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


        [DataType(DataType.Date)]
        [Display(Name = "Data de Inicio")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DataInicio { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Fim")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DataFim { get; set; }



    }
}
