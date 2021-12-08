﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [EmailAddress(ErrorMessage = "Por favor, insira o email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, insira o contacto")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O contacto deve ter 9 caracteres")]
        public string Contacto { get; set; }

        public string Cargo { get; set; }

        public ICollection<Tarefas> Tarefas { get; set; }

        public ICollection<ColaboradorProdutividade> ColaboradorProdutividad { get; set; }

        public ICollection<Colaborador_SprintDesign> Colaborador_Sprints { get; set; }

    }
}
