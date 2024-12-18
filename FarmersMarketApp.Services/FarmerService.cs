﻿using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.ViewModels.AdminViewModels;
using FarmersMarketApp.ViewModels.FarmerViewModels;
using Microsoft.EntityFrameworkCore;
using static FarmersMarketApp.Common.DataValidation.ValidationConstants;

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
				HasProducts = false,
				IsApproved = false,
				IsDeleted = false,
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
			return await repository
				.AllReadOnly<Farmer>()
				.Include(f => f.FarmersFarms)
				.Where(f => f.Id.ToString() == farmerId)
				.Select(f => new FarmerInfoViewModel()
				{
					Id = f.Id.ToString(),
					FullName = f.User.FirstName + " " + f.User.LastName,
					CompanyName = f.CompanyName ?? string.Empty,
					CompanyAddress = f.CompanyAddress ?? string.Empty,
					ImageUrl = f.ImageUrl,
					HasProducts = f.FarmersFarms.Any(f => f.Farm.Products.Any(p => p.IsDeleted == false)),
					IsApproved = f.IsApproved,
					IsDeleted = f.IsDeleted,
				})
				.FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<FarmersForDropDown>> GetAllApprovedAndActiveFarmerNamesAndIdsAsync()
		{
			return await repository
				.AllReadOnly<Farmer>()
				.Where(f => f.IsApproved && !f.IsDeleted)
				.Select(f => new FarmersForDropDown()
				{
					Id = f.Id.ToString(),
					Name = f.User.FirstName + " " + f.User.LastName
				})
				.ToListAsync();
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
					CompanyRegistrationNumber = f.CompanyRegistrationNumber ?? string.Empty,
					ImageUrl = f.ImageUrl,
					IsDeleted = f.IsDeleted,
					IsApproved = f.IsApproved,
					DateApproved = f.DateApproved.HasValue ? f.DateApproved.Value.ToString(DateTimeRequiredFormat) : string.Empty,
				})
				.ToListAsync();

		}

		//get all active farmers
		public async Task<IEnumerable<FarmerInfoViewModel>> GetAllActiveFarmersAsync()
		{
			return await repository
				.AllReadOnly<Farmer>()
				.Include(f => f.FarmersFarms)
				.Where(f => f.IsDeleted == false && f.IsApproved == true)
				.Select(f => new FarmerInfoViewModel()
				{
					Id = f.Id.ToString(),
					FullName = f.User.FirstName + " " + f.User.LastName,
					CompanyName = f.CompanyName ?? string.Empty,
					CompanyAddress = f.CompanyAddress ?? string.Empty,
					ImageUrl = f.ImageUrl,
					HasProducts = f.FarmersFarms.Any(f => f.Farm.Products.Any(p => p.IsDeleted == false)),
					IsApproved = f.IsApproved,
					IsDeleted = f.IsDeleted
				})
				.ToListAsync();

		}

		//admin action to approve farmer
		public async Task<bool> ApproveFarmerByFarmerIdAsync(string farmerId)
		{
			var farmer = await repository.GetByIdAsync<Farmer>(Guid.Parse(farmerId));

			if (farmer == null)
			{
				return false;
			}

			farmer.IsApproved = true;
			farmer.DateApproved = DateTime.Now;

			await repository.SaveChangesAsync();

			return true;
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

		//set farmer and his products is deleted to true
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

		//restore farmer and products
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

		public async Task<IEnumerable<FarmerProductOrderViewModel>?> GetFarmerOpenOrdersAsync(string farmerId)
		{
			//get all farmer farms
			var farmerFarms = await farmService.GetOnlyFarmIdsByFarmerId(farmerId);

			var farmerOrders = new List<FarmerProductOrderViewModel>();

			//for each farm get all orders
			foreach (var farm in farmerFarms)
			{
				var farmOrders = await repository
					.AllReadOnly<ProductOrder>()
					.Where(o => o.FarmId == Guid.Parse(farm))
					.Select(po => new FarmerProductOrderViewModel
					{
						OrderId = po.OrderId.ToString(),
						DeliveryName = po.Order.DeliveryFirstName + " " + po.Order.DeliveryLastName,
						DeliveryAddress = po.Order.DeliveryAddress,
						DeliveryCity = po.Order.DeliveryCity,
						DeliveryPhoneNumber = po.Order.DeliveryPhoneNumber,
						OrderDate = po.Order.CreateDate ?? null,
						Status = po.Status
					})
					.ToListAsync();

				farmerOrders.AddRange(farmOrders);
			}

			farmerOrders = farmerOrders.DistinctBy(o => o.OrderId).ToList();

			foreach (var farmerOrder in farmerOrders)
			{
				farmerOrder.OrderProducts = await productService.GetFarmerProductOrdersByOrderIdAsync(farmerId, farmerOrder.OrderId, farmerFarms);
			}

			return farmerOrders;
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