namespace Microsoft.Extensions.DependencyInjection
{
	using FarmersMarketApp.Infrastructure.Data.Models;
	using Microsoft.AspNetCore.Identity;
	public static class ApplicationBuilderExtensions
	{
		public static async Task SeedRolesAsync(this IApplicationBuilder app)
		{
			using var scope = app.ApplicationServices.CreateScope();
			var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
			string[] roles = { "Admin" };

			foreach (var role in roles)
			{
				if (!await roleManager.RoleExistsAsync(role))
				{
					await roleManager.CreateAsync(new ApplicationRole { Name = role });
				}
			}
		}

		public static async Task EnsureAdminRole(this IApplicationBuilder app)
		{
			using var scope = app.ApplicationServices.CreateScope();
			var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
			var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

			string adminRole = "Admin";
			string adminEmail = "admin@admin.com";
			string defaultAdminPassword = "Admin@123";

			if (!await roleManager.RoleExistsAsync("Admin"))
			{
				var role = new ApplicationRole(adminRole);
				await roleManager.CreateAsync(role);
			}

			var admin = await userManager.FindByEmailAsync("admin@admin.com");

			if (admin == null)
			{
				admin = new ApplicationUser
				{
					FirstName = "Admin",
					LastName = "",
					UserName = adminEmail,
					Email = adminEmail,
					EmailConfirmed = true
				};

				var result = await userManager.CreateAsync(admin, defaultAdminPassword);

				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(admin, adminRole);
				}
			}
			else
			{
				if (!await userManager.IsInRoleAsync(admin, adminRole))
				{
					await userManager.AddToRoleAsync(admin, adminRole);
				}
			}
		}
	}
}
