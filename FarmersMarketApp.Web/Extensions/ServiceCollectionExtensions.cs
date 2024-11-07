namespace FarmersMarketApp.Web.Extensions
{
	using FarmersMarketApp.Infrastructure.Data;
	using FarmersMarketApp.Infrastructure.Data.Models;
	using FarmersMarketApp.Infrastructure.Repositories;
	using FarmersMarketApp.Infrastructure.Repositories.Contracts;
	using FarmersMarketApp.Services;
	using FarmersMarketApp.Services.Contracts;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.DependencyInjection;
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IFarmService, FarmService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IFarmerService, FarmerService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IPaymentService, PaymentService>();
			services.AddScoped<IOrderService, OrderService>();



			return services;
		}

		public static IServiceCollection AddApplicationDbContext(this IServiceCollection services,
			IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

			services
				.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

			services.AddScoped<IRepository, FarmersMarketRepository>();

			//services.AddDatabaseDeveloperPageExceptionFilter();

			return services;
		}

		public static IServiceCollection AddApplicationIdentity(this IServiceCollection services,
			IConfiguration configuration)
		{
			services
				.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
				{
					options.SignIn.RequireConfirmedAccount = false;
					options.SignIn.RequireConfirmedEmail = false;

					options.Password.RequireDigit = false;
					options.Password.RequireLowercase = false;
					options.Password.RequireUppercase = false;
					options.Password.RequireNonAlphanumeric = false;
				})
				.AddEntityFrameworkStores<ApplicationDbContext>();



			return services;
		}

	}
}
