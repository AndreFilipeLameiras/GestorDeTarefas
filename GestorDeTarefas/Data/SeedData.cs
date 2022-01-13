//#define TEST_PAGINATION_TAREFAS

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTarefas.Data
{
    public class SeedData
    {
		private const string ADMIN_EMAIL = "admin@ipg.pt";
		private const string ADMIN_PASS = "Secret123$";

		private const string ROLE_ADMINISTRADOR = "admin";
		private const string ROLE_GESTOR = "gestor";
		private const string ROLE_CLIENTE = "cliente";

		internal static void Populate(GestorDeTarefasContext gestorDeTarefaContext)
		{
#if TEST_PAGINATION_TAREFAS
			Colaborador colaborador = gestorDeTarefaContext.colaborador.FirstOrDefault();

			if (colaborador == null) {
				colaborador = new Colaborador { Name = "Anonymous" };
				 gestorDeTarefaContext.Add(colaborador);
			}

			for (int i = 1; i <= 1000; i++) {
				gestorDeTarefaContext.Tarefas.Add(
					new Tarefas {
						Nome = "Tarefas " + i,
						DataInicio = "Tarefas datainicio " + i,
						Colaborador = colaborador
					}
				);
			}

			gestorDeTarefaContext.SaveChanges();
#endif
		}

		internal static void CreateDefaultAdmin(UserManager<IdentityUser> userManager)
		{
			EnsureUserIsCreatedAsync(userManager, ADMIN_EMAIL, ADMIN_PASS, ROLE_ADMINISTRADOR).Wait();
		}

		private static async Task EnsureUserIsCreatedAsync(UserManager<IdentityUser> userManager, string email, string password, string role)
		{
			var user = await userManager.FindByNameAsync(email);

			if (user == null)
			{

				user = new IdentityUser
				{
					UserName = email,
					Email = email
				};

				await userManager.CreateAsync(user, password);
			}
			if (await userManager.IsInRoleAsync(user, role)) return;
			await userManager.AddToRoleAsync(user, role);
		}

			internal static void PopulateUsers(UserManager<IdentityUser> userManager)
		{
			EnsureUserIsCreatedAsync(userManager, "john@ipg.pt", "Secret123$", ROLE_CLIENTE).Wait();
			EnsureUserIsCreatedAsync(userManager, "mary@ipg.pt", "Secret123$", ROLE_GESTOR).Wait();
		}

		internal static void CreateRoles(RoleManager<IdentityRole> roleManager)
		{
			EnsureRoleIsCreatedAsync(roleManager, ROLE_ADMINISTRADOR).Wait();
			EnsureRoleIsCreatedAsync(roleManager, ROLE_GESTOR).Wait();
			EnsureRoleIsCreatedAsync(roleManager, ROLE_CLIENTE).Wait();

		}

		private static async Task EnsureRoleIsCreatedAsync(RoleManager<IdentityRole> roleManager, string role)
		{
			if (await roleManager.RoleExistsAsync(role)) return;

			await roleManager.CreateAsync(new IdentityRole(role));
		}
	}
}
