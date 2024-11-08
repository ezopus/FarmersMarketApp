using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.ViewModels.FarmerViewModels;
using Microsoft.EntityFrameworkCore;

namespace FarmersMarketApp.Services
{
	public class FarmerService : IFarmerService
	{
		private readonly IRepository repository;
		private readonly IUserService userService;

		public FarmerService(IRepository repository, IUserService userService)
		{
			this.repository = repository;
			this.userService = userService;
		}

		//become a farmer post action
		public async Task<Guid> BecomeFarmerAsync(Guid userId, FarmerBecomeViewModel model)
		{
			var user = await userService.GetCurrentUserByIdAsync(userId);

			var newFarmer = new Farmer()
			{
				Id = Guid.NewGuid(),
				UserId = user!.Id,
				CompanyName = model.CompanyName,
				CompanyAddress = model.CompanyAddress,
				CompanyRegistrationNumber = model.CompanyRegistrationNumber,
				AcceptsDeliveries = model.AcceptsDeliveries!.Value,
				HasProducts = model.HasProducts,
			};

			user.IsFarmer = true;

			await repository.AddAsync<Farmer>(newFarmer);
			await repository.SaveChangesAsync();

			return newFarmer.Id;
		}

		//get specific farmer id if exists
		public async Task<Guid?> GetFarmerIdByUserIdAsync(Guid userId)
		{
			var farmer = await repository
				.AllReadOnly<Farmer>()
				.FirstOrDefaultAsync(f => f.UserId == userId);

			return farmer?.Id;
		}

		public async Task<FarmerInfoViewModel?> GetFarmerIdByAsync(string farmerId)
		{
			return await repository
				.AllReadOnly<Farmer>()
				.Where(f => f.Id.ToString() == farmerId)
				.Select(f => new FarmerInfoViewModel()
				{
					Id = f.Id.ToString(),
					FullName = f.User.FirstName + " " + f.User.LastName,
					CompanyName = f.CompanyName,
					CompanyAddress = f.CompanyAddress,
					ImageUrl = f.ImageUrl,
					AcceptsDeliveries = f.AcceptsDeliveries,
					HasProducts = f.HasProducts
				})
				.FirstOrDefaultAsync();
		}

		//get all farmers
		public async Task<IEnumerable<FarmerInfoViewModel>> GetAllFarmersAsync()
		{
			return await repository
				.AllReadOnly<Farmer>()
				.Select(f => new FarmerInfoViewModel()
				{
					Id = f.Id.ToString(),
					FullName = f.User.FirstName + " " + f.User.LastName,
					CompanyName = f.CompanyName!,
					CompanyAddress = f.CompanyAddress!,
					ImageUrl = f.ImageUrl,
					AcceptsDeliveries = f.AcceptsDeliveries,
					HasProducts = f.HasProducts,
				})
				.ToListAsync();

		}
	}
}
