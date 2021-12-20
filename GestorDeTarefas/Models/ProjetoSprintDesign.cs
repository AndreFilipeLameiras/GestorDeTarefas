﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Models
{
    public class ProjetoSprintDesign
    {
        [Key]
        public int ID_P_Design { get; set; }

        [Display(Name = "Nome do projeto")]
        [Required(ErrorMessage = "Por favor, insira o nome do projeto")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O projeto deve ter entre 3 e 60 caracteres")]
        public string NomeProjeto { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Data Prevista de Inicio")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Por favor, insira a data prevista de inicio")]
        public DateTime DataPrevistaInicio { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Definitiva do Inicio")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Por favor, insira a data definitiva de inicio")]
        public DateTime DataDefinitivaInicio { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Prevista do Fim")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Por favor, insira a data prevista do fim")]
        public DateTime DataPrevistaFim { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Data Definitiva do Fim")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataDefinitivaFim { get; set; }
      

        public ICollection<ColaboradorProjetoSprint> ProjetoSprintColaboradores { get; set; }


    }
}
