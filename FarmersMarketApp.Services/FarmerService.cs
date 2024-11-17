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
		private readonly IFarmService farmService;
		private readonly IProductService productService;
		public FarmerService(
			IRepository repository,
			IUserService userService,
			IFarmService farmService,
			IProductService productService)
		{
			this.repository = repository;
			this.userService = userService;
			this.farmService = farmService;
			this.productService = productService;
		}

		//become a farmer post action
		public async Task<string?> BecomeFarmerAsync(string userId, FarmerBecomeViewModel model)
		{
			var user = await userService.GetCurrentUserByIdAsync(userId);

			if (user == null)
			{
				return null;
			}

			var newFarmer = new Farmer()
			{
				Id = Guid.NewGuid(),
				UserId = user.Id,
				CompanyName = model.CompanyName,
				CompanyAddress = model.CompanyAddress,
				CompanyRegistrationNumber = model.CompanyRegistrationNumber,
				AcceptsDeliveries = model.AcceptsDeliveries!.Value,
				HasProducts = model.HasProducts,
			};

			user.IsFarmer = true;

			await repository.AddAsync(newFarmer);
			await repository.SaveChangesAsync();

			return newFarmer.Id.ToString();
		}

		//get specific farmer id if user id exists
		public async Task<string?> GetFarmerIdByUserIdAsync(string userId)
		{
			if (string.IsNullOrEmpty(userId))
			{
				return null;
			}

			var farmer = await repository
				.AllReadOnly<Farmer>()
				.FirstOrDefaultAsync(f => f.UserId == Guid.Parse(userId));

			return farmer?.Id.ToString();
		}

		public async Task<FarmerInfoViewModel?> GetFarmerByIdAsync(string farmerId)
		{
			//TODO: think about HasProducts and how to use it
			return await repository
				.AllReadOnly<Farmer>()
				.Where(f => f.Id.ToString() == farmerId)
				.Select(f => new FarmerInfoViewModel()
				{
					Id = f.Id.ToString(),
					FullName = f.User.FirstName + " " + f.User.LastName,
					CompanyName = f.CompanyName ?? string.Empty,
					CompanyAddress = f.CompanyAddress ?? string.Empty,
					ImageUrl = f.ImageUrl,
					AcceptsDeliveries = f.AcceptsDeliveries,
					HasProducts = f.HasProducts
				})
				.FirstOrDefaultAsync();
		}

		//get all farmers
		public async Task<IEnumerable<FarmerInfoAdminViewModel>> GetAllFarmersAsync()
		{
			return await repository
				.AllReadOnly<Farmer>()
				.Select(f => new FarmerInfoAdminViewModel()
				{
					Id = f.Id.ToString(),
					FullName = f.User.FirstName + " " + f.User.LastName,
					CompanyName = f.CompanyName ?? string.Empty,
					CompanyAddress = f.CompanyAddress ?? string.Empty,
					ImageUrl = f.ImageUrl,
					IsDeleted = f.IsDeleted,
				})
				.ToListAsync();

		}

		//get all active farmers
		public async Task<IEnumerable<FarmerInfoViewModel>> GetAllActiveFarmersAsync()
		{
			return await repository
				.AllReadOnly<Farmer>()
				.Where(f => f.IsDeleted == false)
				.Select(f => new FarmerInfoViewModel()
				{
					Id = f.Id.ToString(),
					FullName = f.User.FirstName + " " + f.User.LastName,
					CompanyName = f.CompanyName ?? string.Empty,
					CompanyAddress = f.CompanyAddress ?? string.Empty,
					ImageUrl = f.ImageUrl,
					AcceptsDeliveries = f.AcceptsDeliveries,
					HasProducts = f.HasProducts,
				})
				.ToListAsync();

		}

		//set farmer is deleted 
		public async Task<bool> SetFarmerIsDeletedByIdAsync(string farmerId)
		{
			var farmerToDelete = await repository.GetByIdAsync<Farmer>(Guid.Parse(farmerId));

			if (farmerToDelete == null)
			{
				return false;
			}

			farmerToDelete.IsDeleted = true;
			await repository.SaveChangesAsync();

			return true;
		}
		//set farmer is deleted 
		public async Task<bool> SetFarmerFarmsProductsIsDeletedByIdAsync(string farmerId)
		{
			var farmerToDelete = await repository.GetByIdAsync<Farmer>(Guid.Parse(farmerId));

			if (farmerToDelete == null)
			{
				return false;
			}

			var farmerFarms = await farmService.GetAllFarmsByFarmerIdForDeletion(farmerId);

			if (farmerFarms.Any())
			{
				foreach (var farm in farmerFarms)
				{
					farm.IsDeleted = true;
				}
			}

			var farmerProducts = await productService.GetProductsForDeletionByFarmerIdAsync(farmerId);

			if (farmerProducts.Any())
			{
				foreach (var product in farmerProducts)
				{
					product.IsDeleted = true;
				}
			}

			farmerToDelete.IsDeleted = true;
			await repository.SaveChangesAsync();
			return true;
		}

		//restore farmer 
		public async Task<bool> RestoreFarmerFarmsProductsByIdAsync(string farmerId)
		{
			var farmerToDelete = await repository.GetByIdAsync<Farmer>(Guid.Parse(farmerId));

			if (farmerToDelete == null)
			{
				return false;
			}
			var farmerFarms = await farmService.GetAllFarmsByFarmerIdForDeletion(farmerId);

			if (farmerFarms.Any())
			{
				foreach (var farm in farmerFarms)
				{
					farm.IsDeleted = false;
				}
			}

			var farmerProducts = await productService.GetProductsForDeletionByFarmerIdAsync(farmerId);

			if (farmerProducts.Any())
			{
				foreach (var product in farmerProducts)
				{
					product.IsDeleted = false;
				}
			}

			farmerToDelete.IsDeleted = false;
			await repository.SaveChangesAsync();
			return true;
		}
		//restore farmer 
		public async Task<bool> RestoreFarmerByIdAsync(string farmerId)
		{
			var farmerToDelete = await repository.GetByIdAsync<Farmer>(Guid.Parse(farmerId));

			if (farmerToDelete == null)
			{
				return false;
			}

			farmerToDelete.IsDeleted = false;
			await repository.SaveChangesAsync();

			return true;
		}
	}
}
