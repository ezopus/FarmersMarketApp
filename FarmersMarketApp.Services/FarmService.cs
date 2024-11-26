using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.ViewModels.AdminViewModels;
using FarmersMarketApp.Web.ViewModels.FarmViewModels;
using FarmersMarketApp.Web.ViewModels.ProductViewModels;
using Microsoft.EntityFrameworkCore;
using static FarmersMarketApp.Common.DataValidation.ValidationConstants;

namespace FarmersMarketApp.Services
{
	public class FarmService : IFarmService
	{
		private readonly IRepository repository;
		private readonly IProductService productService;
		public FarmService(
			IRepository repository,
			IProductService productService)
		{
			this.repository = repository;
			this.productService = productService;
		}

		//get all active farms async
		public async Task<IEnumerable<FarmInfoAdminViewModel>> GetAllFarmsAsync()
		{
			return await repository
				.AllAsync<Farm>()
				.Select(f => new FarmInfoAdminViewModel()
				{
					Id = f.Id.ToString(),
					Name = f.Name,
					Address = f.Address,
					City = f.City,
					ImageUrl = f.ImageUrl,
					IsDeleted = f.IsDeleted,
				})
				.ToListAsync();
		}

		//get all active farms async
		public async Task<IEnumerable<FarmInfoViewModel>> GetActiveFarmsAsync()
		{
			return await repository
				.AllAsync<Farm>()
				.Where(f => !f.IsDeleted)
				.Select(f => new FarmInfoViewModel()
				{
					Id = f.Id.ToString(),
					Name = f.Name,
					Address = f.Address,
					PhoneNumber = f.PhoneNumber,
					City = f.City,
					CloseHours = f.CloseHours.ToString(),
					OpenHours = f.OpenHours.ToString(),
					Email = f.Email,
					ImageUrl = f.ImageUrl,
					FarmersFarms = f.FarmersFarms,
					Products = f.Products,
				})
				.ToListAsync();
		}

		//get all farms of specific farmer
		public async Task<ICollection<FarmInfoViewModel>?> GetAllFarmsByFarmerIdAsync(string farmerId)
		{
			var farms = await repository
				.AllReadOnly<Farm>()
				.Where(f => f.FarmersFarms.All(fm => fm.FarmerId == Guid.Parse(farmerId))
							&& !f.IsDeleted)
				.Select(f => new FarmInfoViewModel()
				{
					Id = f.Id.ToString(),
					Name = f.Name,
					Address = f.Address,
					PhoneNumber = f.PhoneNumber,
					City = f.City,
					CloseHours = f.CloseHours.ToString(),
					OpenHours = f.OpenHours.ToString(),
					Email = f.Email,
					ImageUrl = f.ImageUrl,
					FarmersFarms = f.FarmersFarms,
					Products = f.Products,
				})
				.ToListAsync();

			return farms;
		}

		public async Task<IEnumerable<FarmsForDropDown>> GetAllFarmNamesAndIdsAsync()
		{
			return await repository
				.AllReadOnly<Farm>()
				.Select(f => new FarmsForDropDown()
				{
					Id = f.Id.ToString(),
					Name = f.Name,
				})
				.ToListAsync();
		}

		//get read-only copy of specific farm by id async
		public async Task<FarmInfoViewModel?> GetFarmByIdReadOnlyAsync(string id)
		{
			var farm = await repository
				.AllReadOnly<Farm>()
				.Where(f => !f.IsDeleted)
				.FirstOrDefaultAsync(f => f.Id == Guid.Parse(id));

			if (farm == null)
			{
				return null;
			}

			var model = new FarmInfoViewModel()
			{
				Id = farm.Id.ToString(),
				Name = farm.Name,
				Address = farm.Address,
				PhoneNumber = farm.PhoneNumber,
				City = farm.City,
				CloseHours = farm.CloseHours?.ToString(TimeRequiredFormat),
				OpenHours = farm.OpenHours?.ToString(TimeRequiredFormat),
				Email = farm.Email,
				ImageUrl = farm.ImageUrl,
				FarmersFarms = farm.FarmersFarms,
				Products = farm.Products,
			};

			return model;
		}

		//get tracked entity of specific farm by id async
		public async Task<AddFarmViewModel?> GetFarmToEditByIdAsync(string id)
		{
			var farm = await repository
				.AllAsync<Farm>()
				.Where(f => !f.IsDeleted)
				.FirstOrDefaultAsync(f => f.Id == Guid.Parse(id));

			if (farm == null)
			{
				return null;
			}

			var model = new AddFarmViewModel()
			{
				Id = farm.Id.ToString(),
				Name = farm.Name,
				Address = farm.Address,
				PhoneNumber = farm.PhoneNumber,
				City = farm.City,
				CloseHours = farm.CloseHours?.ToString(TimeRequiredFormat),
				OpenHours = farm.OpenHours?.ToString(TimeRequiredFormat),
				Email = farm.Email,
				ImageUrl = farm.ImageUrl,
			};

			return model;
		}

		//Used for validation in views to show edit button only for farmers part of specific farm
		public async Task<ICollection<string>?> GetOnlyFarmIdsByFarmerId(string farmerId)
		{
			if (string.IsNullOrEmpty(farmerId))
			{
				return null;
			}

			var farms = await repository
				.AllReadOnly<Farm>()
				.Where(f => f.FarmersFarms.All(fm => fm.FarmerId == Guid.Parse(farmerId))
							&& !f.IsDeleted)
				.Select(f => f.Id.ToString())
				.ToListAsync();

			return farms;
		}

		//add new farm to currently logged in farmer
		public async Task<string> AddNewFarmAsync(AddFarmViewModel model, string farmerId)
		{
			var newFarm = new Farm()
			{
				Id = Guid.NewGuid(),
				Name = model.Name,
				Address = model.Address,
				City = model.City,
				Email = model.Email,
				PhoneNumber = model.PhoneNumber,
				ImageUrl = model.ImageUrl,
				OpenHours = model.OpenHours != null
					? TimeOnly.Parse(model.OpenHours)
					: null,
				CloseHours = model.CloseHours != null
					? TimeOnly.Parse(model.CloseHours)
					: null,
				IsOpen = false,
			};

			var newFarmerFarm = new FarmerFarm()
			{
				FarmId = newFarm.Id,
				FarmerId = Guid.Parse(farmerId)
			};

			newFarm.FarmersFarms.Add(newFarmerFarm);

			await repository.AddAsync(newFarm);
			await repository.AddAsync(newFarmerFarm);
			await repository.SaveChangesAsync();

			return newFarm.Id.ToString();
		}

		public async Task<bool> EditFarmAsync(AddFarmViewModel model)
		{
			var farmToEdit = await repository
				.AllAsync<Farm>()
				.Where(f => !f.IsDeleted)
				.FirstOrDefaultAsync(f => f.Id == Guid.Parse(model.Id));

			if (farmToEdit == null)
			{
				return false;
			}

			farmToEdit.Name = model.Name;
			farmToEdit.Address = model.Address;
			farmToEdit.City = model.City;
			farmToEdit.Email = model.Email;
			farmToEdit.PhoneNumber = model.PhoneNumber;
			farmToEdit.ImageUrl = model.ImageUrl;
			farmToEdit.OpenHours = model.OpenHours != null
				? TimeOnly.Parse(model.OpenHours)
				: null;
			farmToEdit.CloseHours = model.CloseHours != null
				? TimeOnly.Parse(model.CloseHours)
				: null;

			await repository.SaveChangesAsync();

			return true;
		}

		public async Task<IEnumerable<AddProductFarmOptions>?> GetFarmNameAndIdForNewProductAsync(string farmerId)
		{
			return await repository
				.AllReadOnly<Farm>()
				.Where(f => f.FarmersFarms.Any(fm => fm.FarmerId == Guid.Parse(farmerId)) && !f.IsDeleted)
				.Select(f => new AddProductFarmOptions()
				{
					Id = f.Id.ToString(),
					Name = f.Name,
					ImageUrl = f.ImageUrl,
					Address = f.Address,
					City = f.City,
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<AddProductFarmOptions>> GetThreeRandomFarmsForIndexCarousel()
		{
			var farms = await repository
				.AllReadOnly<Farm>()
				.Where(f => !f.IsDeleted)
				.Select(f => new AddProductFarmOptions()
				{
					Id = f.Id.ToString(),
					Name = f.Name,
					Address = f.Address,
					City = f.City,
					ImageUrl = !string.IsNullOrEmpty(f.ImageUrl)
						? f.ImageUrl
						: "/img/no-image.png",
				})
				.ToListAsync();

			var randomFarms = new List<AddProductFarmOptions>();
			var random = new Random();
			var counter = 0;

			while (farms.Count > 1 && counter < 3)
			{
				var index = random.Next(0, farms.Count - 1);
				randomFarms.Add(farms[index]);
				farms.RemoveAt(index);
				counter++;
			}

			return randomFarms;
		}

		public async Task<IEnumerable<Farm>> GetAllFarmsByFarmerIdForDeletion(string farmerId)
		{
			return await repository.AllAsync<Farm>()
				.Where(f => f.FarmersFarms.All(fm => fm.FarmerId == Guid.Parse(farmerId)))
				.ToListAsync();
		}

		public async Task<bool> SetFarmIsDeletedByFarmIdAsync(string farmId)
		{
			var farmToDelete = await repository.GetByIdAsync<Farm>(Guid.Parse(farmId));
			if (farmToDelete == null)
			{
				return false;
			}

			var productsToDelete = await productService.GetProductsForDeletionByFarmIdAsync(farmId);

			if (productsToDelete.Any())
			{
				foreach (var product in productsToDelete)
				{
					product.IsDeleted = true;
				}
			}

			farmToDelete.IsDeleted = true;
			await repository.SaveChangesAsync();

			return true;
		}
		public async Task<bool> RestoreFarmByFarmIdAsync(string farmId)
		{
			var farmToDelete = await repository.GetByIdAsync<Farm>(Guid.Parse(farmId));
			if (farmToDelete == null)
			{
				return false;
			}

			var productsToDelete = await productService.GetProductsForDeletionByFarmIdAsync(farmId);

			if (productsToDelete.Any())
			{
				foreach (var product in productsToDelete)
				{
					product.IsDeleted = false;
				}
			}

			farmToDelete.IsDeleted = false;
			await repository.SaveChangesAsync();

			return true;
		}
	}
}
