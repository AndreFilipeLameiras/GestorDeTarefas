using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Models
{
    public class Contacto
    {
        public int ContactoId { get; set; }

        [Required(ErrorMessage = "Por favor, insira seu Nome")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "O nome deve ter pelo menos 2 caracteres e um máximo de 20")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Por favor, insira seu Sobrenome")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "O Sobrenome deve ter pelo menos 2 caracteres e um máximo de 20")]
        public string Sobrenome { get; set; }



        [Required(ErrorMessage = "Por favor, introduza o email")]
        [EmailAddress(ErrorMessage = "Por favor digite um email válido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Por favor, escreva o assunto")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Assunto deve ter pelo menos 4 caracteres e um máximo de 20")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "Por favor, escreva a mensagem")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Mensagem deve ter pelo menos 2 caracteres e um máximo de 1000")]
        public string Mensagem { get; set; }

        public bool Verificado { get; set; }

        [Display(Name = "Resposta")]
        public string Resposta { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataEnvio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DataResposta { get; set; }

    }
}
