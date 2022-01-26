using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.ViewModels
{
    public class RegistarColaboradorViewModel
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public int CargoId { get; set; }

        public IEnumerable<SelectListItem> Cargo { get; set; }

        [Required]
        [StringLength(256)]
        [EmailAddress(ErrorMessage = "Por favor, insira o email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, insira o contacto")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O contacto deve ter 9 caracteres")]
        [RegularExpression(@"(9\d{8})", ErrorMessage = "Numero invalido.")]
        public string Contacto { get; set; }


    }
}
