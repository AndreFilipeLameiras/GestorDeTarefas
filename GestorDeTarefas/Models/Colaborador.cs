using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Models
{
    public class Colaborador
    {
        public int ColaboradorId { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Por favor, insira o email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, insira o contacto")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O contacto deve ter 9 caracteres")]
        public string Contacto { get; set; }

        //[ForeignKey("FK_CargoId")]
        //[DisplayName("Cargo")]
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }

        public ICollection<Tarefas> Tarefas { get; set; }

        public ICollection<ColaboradorProdutividade> ColaboradorProdutividade { get; set; }

        public ICollection<ColaboradorProjetoSprint> ColaboradorProjetoSprints { get; set; }

        public ICollection<ColaboradorIdioma> ColaboradorIdiomas { get; set; }

        

    }
}
