using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.ViewModels.FarmerViewModels;

namespace FarmersMarketApp.Services
{
	public class FarmerService : IFarmerService
	{
		private readonly IRepository repository;
		public FarmerService(IRepository repository)
		{
			this.repository = repository;
		}
		public async Task<Guid> BecomeFarmerAsync(ApplicationUser user, FarmerBecomeViewModel model)
		{
			var newFarmer = new Farmer()
			{
				Id = Guid.NewGuid(),
				UserId = user.Id,
				CompanyName = model.CompanyName,
				CompanyAddress = model.CompanyAddress,
				CompanyRegistrationNumber = model.CompanyRegistrationNumber,
				AcceptsDeliveries = model.AcceptsDeliveries.Value,
				HasProducts = model.HasProducts,
			};

			user.IsFarmer = true;

			await repository.AddAsync<Farmer>(newFarmer);
			await repository.SaveChangesAsync();

			return newFarmer.Id;
		}


	}
}
