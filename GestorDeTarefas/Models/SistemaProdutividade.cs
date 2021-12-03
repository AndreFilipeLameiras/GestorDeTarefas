using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Models
{
    public class SistemaProdutividade
    {
        public int SistemaProdutividadeId { get; set; }


        [Required]
        [StringLength(256)]
        public string Nome { get; set; }

        [StringLength(256)]
        public string O_que_fazer { get; set; }

        [StringLength(256)]
        public string Estamos_a_fazer { get; set; }

        [StringLength(256)]
        public string Concluido { get; set; }

        

        
        public ICollection<ColaboradorProdutividade> ProdutividadeColaborador { get; set; }
    }
}
