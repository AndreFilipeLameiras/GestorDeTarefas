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
			if (db.ProjetoSprintDesign.Any()) return;
			db.ProjetoSprintDesign.AddRange(
				new ProjetoSprintDesign { NomeProjeto = "Kayak"}
				
			);

			db.SaveChanges();
		}
	}
}


