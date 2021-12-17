using GestorDeTarefas.Models;
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

            if (!db.ProjetoSprintDesign.Any())
            {
                db.ProjetoSprintDesign.AddRange(new List<ProjetoSprintDesign>() {
                            SeedDataProjeto.CriarEvento(db,"Montagem"),
                            SeedDataProjeto.CriarEvento(db,"Construção"),
                            SeedDataProjeto.CriarEvento(db,"Limpesa"),
                            });
                db.SaveChangesAsync().GetAwaiter().GetResult();


            }
        }

        private static ProjetoSprintDesign CriarEvento(GestorDeTarefasContext db, string nome)
        {




            return new ProjetoSprintDesign()
            {
                NomeProjeto = nome.Split(' ')[0]

            };
        }
    }
}

