using GestorDeTarefas.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Data
{
    public class SeedDataProjeto
    {
        internal static void Populate(GestorDeTarefasContext db)
        {
            PopulateProjetoSprint(db);
            PopulateCargo(db);
            PopulateColaborador(db);
            PopulateTarefas(db);
            PopulateIdioma(db);

        }
         

        private static void PopulateProjetoSprint(GestorDeTarefasContext db)
        {
            if (db.ProjetoSprintDesign.Any()) return;
            db.ProjetoSprintDesign.AddRange(
                new ProjetoSprintDesign { NomeProjeto = "Kayak" },
                new ProjetoSprintDesign { NomeProjeto = "Criação de automovel" },
                new ProjetoSprintDesign { NomeProjeto = "Construção Civil" },
                new ProjetoSprintDesign { NomeProjeto = "Reparação de computadores" },
                new ProjetoSprintDesign { NomeProjeto = "Manutenção de estrada" }

            );

            db.SaveChanges();
        } 


        private static void PopulateCargo(GestorDeTarefasContext db)
        {
            if (db.Cargo.Any())
            {
                return;
            }

            db.Cargo.AddRange(
                new Cargo { Nome_Cargo = "Professor" },
                new Cargo { Nome_Cargo = "Eletricista" },
                new Cargo { Nome_Cargo = "Mecanico" },
                new Cargo { Nome_Cargo = "Encarregado" },
                new Cargo { Nome_Cargo = "Ajudante" }

            );

            db.SaveChanges();
        }

        private static void PopulateColaborador(GestorDeTarefasContext db)
        {
            if (db.Colaborador.Any())
            {
                return;
            }

            db.Colaborador.AddRange(
                new Colaborador { 
                    Name="James Ruan",
                    CargoId=1,
                    Contacto = "930256963",
                    Email="james@gmail.com",
                    
                },
                 new Colaborador
                 {
                     Name = "Joel Matos",
                     CargoId = 2,
                     Contacto = "927256978",
                     Email = "matos@gmail.com",

                 },
                  new Colaborador
                  {
                      Name = "Cyntia Alves",
                      CargoId = 3,
                      Contacto = "930256950",
                      Email = "alves@gmail.com",

                  },
                   new Colaborador
                   {
                       Name = "Ruan Lima",
                       CargoId = 5,
                       Contacto = "913256963",
                       Email = "limaruan@gmail.com",

                   },
                    new Colaborador
                    {
                        Name = "Beatriz Mendes",
                        CargoId = 4,
                        Contacto = "925369741",
                        Email = "bea@gmail.com",

                    }



            );

            db.SaveChanges();
        }


        private static void PopulateTarefas(GestorDeTarefasContext db)
        {
            if (db.Tarefas.Any())
            {
                return;
            }

            db.Tarefas.AddRange(
                new Tarefas { 
                    Nome="Limpeza",
                    ColaboradorId=1,ID_P_Design=3,
                    DataDefinitivaInicio=DateTime.Today.Date,
                    DataPrevistaInicio=DateTime.Parse("10/12/2021"),
                    DataPrevistaFim = DateTime.Parse("30/12/2021"),
                    DataDefinitivaFim=default
                },
                new Tarefas
                {
                    Nome = "Pintar",
                    ColaboradorId = 3,
                    ID_P_Design = 2,
                    DataDefinitivaInicio = DateTime.Today.Date,
                    DataPrevistaInicio = DateTime.Parse("10/07/2021"),
                    DataPrevistaFim = DateTime.Parse("25/11/2021"),
                    DataDefinitivaFim = default
                },
                new Tarefas
                {
                    Nome = "Montar",
                    ColaboradorId = 4,
                    ID_P_Design = 1,
                    DataDefinitivaInicio = DateTime.Today.Date,
                    DataPrevistaInicio = DateTime.Parse("10/12/2021"),
                    DataPrevistaFim = DateTime.Parse("30/12/2021"),
                    DataDefinitivaFim = default
                },
                new Tarefas
                {
                    Nome = "Martelar Pneu",
                    ColaboradorId = 5,
                    ID_P_Design = 5,
                    DataDefinitivaInicio = DateTime.Today.Date,
                    DataPrevistaInicio = DateTime.Parse("10/12/2021"),
                    DataPrevistaFim = DateTime.Parse("30/12/2021"),
                    DataDefinitivaFim = default
                },
                new Tarefas
                {
                    Nome = "Limpeza",
                    ColaboradorId = 1,
                    ID_P_Design = 3,
                    DataDefinitivaInicio = DateTime.Today.Date,
                    DataPrevistaInicio = DateTime.Parse("10/12/2021"),
                    DataPrevistaFim = DateTime.Parse("30/12/2021"),
                    DataDefinitivaFim = default
                }



            );

            db.SaveChanges();
        }


       


        private static void PopulateIdioma(GestorDeTarefasContext db)
        {
            if (db.Idioma.Any())
            {
                return;
            }

            db.Idioma.AddRange(
                new Idioma
                {
                    NomeIdioma = "Português"

                },
               new Idioma
               {
                   NomeIdioma = "Françês"

               },
               new Idioma
               {
                   NomeIdioma = "Inglês"

               },
               new Idioma
               {
                   NomeIdioma = "Espanhol"

               },
               new Idioma
               {
                   NomeIdioma = "Alemão"

               }


            );

            db.SaveChanges();
        }



    }
}


