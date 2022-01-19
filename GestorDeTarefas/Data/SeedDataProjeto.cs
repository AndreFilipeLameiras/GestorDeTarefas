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
            PopulateCliente(db);
            PopulateCargo(db);
            PopulateColaborador(db);
            PopulateProjetoProdutividade(db);
            PopulateProjetoSprint(db);
            
            PopulateTarefas(db);
            PopulateIdioma(db);
             
        }
         

        private static void PopulateProjetoSprint(GestorDeTarefasContext db)
        {
            if (db.ProjetoSprintDesign.Any()) return;
            db.ProjetoSprintDesign.AddRange(
                new ProjetoSprintDesign { NomeProjeto = "Kayak",
                DataPrevistaInicio=DateTime.Parse("20/12/2021"),
                DataDefinitivaInicio = DateTime.Parse("18/12/2021"),
                DataPrevistaFim = DateTime.Parse("22/12/2021"),
                EstadoProjeto="Dentro do prazo",
                ClienteId=1,
                ColaboradorId =1
                
                },
                new ProjetoSprintDesign { NomeProjeto = "Criação de automovel",
                    DataPrevistaInicio = DateTime.Parse("20/12/2021"),
                    DataDefinitivaInicio = DateTime.Parse("18/12/2021"),
                    DataPrevistaFim = DateTime.Parse("22/12/2021"),
                    EstadoProjeto = "Dentro do prazo",
                    ClienteId = 2,
                    ColaboradorId = 2
                },
                new ProjetoSprintDesign { NomeProjeto = "Construção Civil",
                    DataPrevistaInicio = DateTime.Parse("16/12/2021"),
                    DataDefinitivaInicio = DateTime.Parse("18/12/2021"),
                    DataPrevistaFim = DateTime.Parse("22/12/2021"),
                    EstadoProjeto = "Em atraso",
                    ClienteId = 4,
                    ColaboradorId = 3
                },
                new ProjetoSprintDesign { NomeProjeto = "Reparação de computadores",
                    DataPrevistaInicio = DateTime.Parse("20/09/2021"),
                    DataDefinitivaInicio = DateTime.Parse("18/11/2021"),
                    DataPrevistaFim = DateTime.Parse("22/12/2021"),
                    EstadoProjeto = "Em atraso",
                    ClienteId = 2,
                    ColaboradorId = 1
                },
                new ProjetoSprintDesign { NomeProjeto = "Manutenção de estrada",
                    DataPrevistaInicio = DateTime.Parse("20/12/2021"),
                    DataDefinitivaInicio = DateTime.Parse("18/12/2021"),
                    DataPrevistaFim = DateTime.Parse("22/12/2021"),
                    EstadoProjeto = "Dentro do prazo",
                    ClienteId = 2,
                    ColaboradorId = 3

                }

            );

            db.SaveChanges();
        }


        private static void PopulateProjetoProdutividade(GestorDeTarefasContext db)
        {
            if (db.SistemaProdutividade.Any()) return;
            db.SistemaProdutividade.AddRange(
                new SistemaProdutividade
                {
                    NomeProjeto = "Produção JM",
                    DataPrevistaInicio = DateTime.Parse("20/12/2021"),
                    DataDefinitivaInicio = DateTime.Parse("18/12/2021"),
                    DataPrevistaFim = DateTime.Parse("22/12/2021"),
                    EstadoProjeto = "Dentro do prazo"

                },
                new SistemaProdutividade
                {
                    NomeProjeto = "Arca Produções",
                    DataPrevistaInicio = DateTime.Parse("20/12/2021"),
                    DataDefinitivaInicio = DateTime.Parse("18/12/2021"),
                    DataPrevistaFim = DateTime.Parse("22/12/2021"),
                    EstadoProjeto = "Dentro do prazo"
                },
                new SistemaProdutividade
                {
                    NomeProjeto = "Toneladas KL",
                    DataPrevistaInicio = DateTime.Parse("16/12/2021"),
                    DataDefinitivaInicio = DateTime.Parse("18/12/2021"),
                    DataPrevistaFim = DateTime.Parse("22/12/2021"),
                    EstadoProjeto = "Em atraso"
                },
                new SistemaProdutividade
                {
                    NomeProjeto = "Reparação de Portas",
                    DataPrevistaInicio = DateTime.Parse("20/09/2021"),
                    DataDefinitivaInicio = DateTime.Parse("18/11/2021"),
                    DataPrevistaFim = DateTime.Parse("22/12/2021"),
                    EstadoProjeto = "Em atraso"
                },
                new SistemaProdutividade
                {
                    NomeProjeto = "Manutenção de Hotel",
                    DataPrevistaInicio = DateTime.Parse("20/12/2021"),
                    DataDefinitivaInicio = DateTime.Parse("18/12/2021"),
                    DataPrevistaFim = DateTime.Parse("22/12/2021"),
                    EstadoProjeto = "Dentro do prazo"
                }

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
                new Cargo { Nome_Cargo = "Gestor" },
                new Cargo { Nome_Cargo = "Eletricista" },
                new Cargo { Nome_Cargo = "Mecanico" },
                new Cargo { Nome_Cargo = "Encarregado" },
                new Cargo { Nome_Cargo = "Ajudante" },
                new Cargo { Nome_Cargo = "Servente" },
                new Cargo { Nome_Cargo = "Motorista" },
                new Cargo { Nome_Cargo = "Bate Chapas" },
                new Cargo { Nome_Cargo = "Pintor" }

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
                    
                    Name = "Cezar Antonio",
                    CargoId = 1,
                    Contacto = "930256963",
                    Email = "cezar@gmail.com",
                    
                },
                new Colaborador
                {
                    
                    Name = "Luisa Alves",
                    CargoId = 1,
                    Contacto = "930256963",
                    Email = "Luisa@gmail.com",

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
                    ColaboradorId=1,
                    ProjetoSprintDesignID=3,
                    SistemaProdutividadeId=1,
                    DataPrevistaInicio = DateTime.Parse("20/09/2021"),
                    DataDefinitivaInicio = DateTime.Parse("18/11/2021"),
                    DataPrevistaFim = DateTime.Parse("22/12/2021"),
                    EstadoTarefa = "Em atraso"
                },
                new Tarefas
                {
                    Nome = "Pintar",
                    ColaboradorId = 3,
                    ProjetoSprintDesignID = 2,
                    SistemaProdutividadeId = 1,
                    DataPrevistaInicio = DateTime.Parse("20/12/2021"),
                    DataDefinitivaInicio = DateTime.Parse("18/12/2021"),
                    DataPrevistaFim = DateTime.Parse("22/12/2021"),
                    EstadoTarefa= "Dentro do prazo"
                },
                new Tarefas
                {
                    Nome = "Montar",
                    ColaboradorId = 4,
                    ProjetoSprintDesignID = 1,
                    DataPrevistaInicio = DateTime.Parse("20/12/2021"),
                    DataDefinitivaInicio = DateTime.Parse("18/12/2021"),
                    DataPrevistaFim = DateTime.Parse("22/12/2021"),
                    EstadoTarefa = "Dentro do prazo"
                },
                new Tarefas
                {
                    Nome = "Martelar Pneu",
                    ColaboradorId = 5,
                    ProjetoSprintDesignID = 5,
                    DataPrevistaInicio = DateTime.Parse("20/12/2021"),
                    DataDefinitivaInicio = DateTime.Parse("18/12/2021"),
                    DataPrevistaFim = DateTime.Parse("22/12/2021"),
                    EstadoTarefa = "Dentro do prazo"
                },
                new Tarefas
                {
                    Nome = "Arumar materiais",
                    ColaboradorId = 1,
                    ProjetoSprintDesignID = 3,
                    SistemaProdutividadeId = 4,
                    DataPrevistaInicio = DateTime.Parse("20/09/2021"),
                    DataDefinitivaInicio = DateTime.Parse("18/11/2021"),
                    DataPrevistaFim = DateTime.Parse("22/12/2021"),
                    EstadoTarefa = "Em atraso"
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



        private static void PopulateCliente(GestorDeTarefasContext db)
        {
            if (db.Cliente.Any())
            {
                return;
            }

            db.Cliente.AddRange(
                new Cliente
                {
                    Nome = "Jonas Paulo",
                    Email ="jonaspaulo@gmail.com",
                    Cidade="Lisboa",
                    Phone="923456654"                 
                },
               new Cliente
               {
                   Nome = "Miguel Silva",
                   Email = "miguel@gmail.com",
                   Cidade = "Porto",
                   Phone = "923456659"
               },
               new Cliente
               {
                   Nome = "Ana Matos",
                   Email = "ana@gmail.com",
                   Cidade = "Lisboa",
                   Phone = "923456610"
               },
               new Cliente
               {
                   Nome = "Patricia Andreza",
                   Email = "andreza@gmail.com",
                   Cidade = "Guarda",
                   Phone = "923456654"
               },
               new Cliente
               {
                   Nome = "Cleiton Mendes",
                   Email = "cleinton@gmail.com",
                   Cidade = "Lisboa",
                   Phone = "923456610"
               },
               new Cliente
               {
                   Nome = "Luis Manteiga",
                   Email = "Manteiga@gmail.com",
                   Cidade = "Aveiro",
                   Phone = "923456654"
               }


            );

            db.SaveChanges();
        }



        
    }
}


