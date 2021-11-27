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

		private const string ROLE_ADMINISTRATOR = "admin";
		private const string ROLE_PRODUCT_MANAGER = "product_manager";
		private const string ROLE_CUSTOMER = "customer";

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
			EnsureUserIsCreatedAsync(userManager, ADMIN_EMAIL, ADMIN_PASS).Wait();
		}

		private static async Task EnsureUserIsCreatedAsync(UserManager<IdentityUser> userManager, string email, string password)
		{
			var user = await userManager.FindByNameAsync(email);
			if (user != null) return;

			user = new IdentityUser
			{
				UserName = email,
				Email = email
			};

			await userManager.CreateAsync(user, password);
		}

		internal static void PopulateUsers(UserManager<IdentityUser> userManager)
		{

		}

		internal static void CreateRoles(RoleManager<IdentityRole> roleManager)
		{
			EnsureRoleIsCreatedAsync(roleManager, ROLE_ADMINISTRATOR).Wait();
			EnsureRoleIsCreatedAsync(roleManager, ROLE_PRODUCT_MANAGER).Wait();
			EnsureRoleIsCreatedAsync(roleManager, ROLE_CUSTOMER).Wait();
		}

		private static async Task EnsureRoleIsCreatedAsync(RoleManager<IdentityRole> roleManager, string role)
		{
			if (await roleManager.RoleExistsAsync(role)) return;

			await roleManager.CreateAsync(new IdentityRole(role));
		}
	}
}
