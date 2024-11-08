using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.ViewModels.FarmViewModels;
using FarmersMarketApp.Web.ViewModels.ProductViewModels;
using Microsoft.EntityFrameworkCore;
using static FarmersMarketApp.Common.DataValidation.ValidationConstants;

namespace FarmersMarketApp.Services
{
	public class FarmService : IFarmService
	{
		private readonly IRepository repository;
		public FarmService(IRepository repository)
		{
			this.repository = repository;
		}

		//get all farms async
		public async Task<IEnumerable<FarmInfoViewModel>> GetFarmsAsync()
		{
			return await repository
				.AllAsync<Farm>()
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

		//get read-only copy of specific farm by id async
		public async Task<FarmInfoViewModel?> GetFarmByIdReadOnlyAsync(Guid id)
		{
			var farm = await repository
				.AllReadOnly<Farm>()
				.FirstOrDefaultAsync(f => f.Id == id);

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
		public async Task<AddFarmViewModel> GetFarmToEditByIdAsync(Guid id)
		{
			var farm = await repository
				.AllAsync<Farm>()
				.FirstOrDefaultAsync(f => f.Id == id);

			if (farm == null)
			{
				return null;
			}

			var model = new AddFarmViewModel()
			{
				Id = farm.Id,
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

		//get all farms of specific farmer
		public async Task<IEnumerable<FarmInfoViewModel?>> GetFarmsByFarmerIdAsync(Guid farmerId)
		{
			var farms = await repository
				.AllReadOnly<Farm>()
				.Where(f => f.FarmersFarms.All(fm => fm.FarmerId == farmerId))
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

		//Used for validation in views to show edit button only for farmers part of specific farm
		public async Task<ICollection<string>> GetFarmIdsByFarmerId(Guid farmerId)
		{
			return await repository
				.AllReadOnly<Farm>()
				.Where(f => f.FarmersFarms.All(fm => fm.FarmerId == farmerId))
				.Select(f => f.Id.ToString())
				.ToListAsync();
		}

		//add new farm to currently logged in farmer
		public async Task<Farm> AddNewFarmAsync(AddFarmViewModel model, Guid farmerId)
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
				FarmerId = farmerId
			};

			newFarm.FarmersFarms.Add(newFarmerFarm);

			await repository.AddAsync(newFarm);
			await repository.AddAsync(newFarmerFarm);
			await repository.SaveChangesAsync();

			return newFarm;
		}

		public async Task<bool> EditFarmAsync(AddFarmViewModel model)
		{
			var farmToEdit = await repository
				.AllAsync<Farm>()
				.FirstOrDefaultAsync(f => f.Id == model.Id);

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

		public async Task<List<AddProductFarmOptions>> GetFarmNameAndIdForNewProductAsync(Guid farmerId)
		{
			return await repository
				.AllReadOnly<Farm>()
				.Where(f => f.FarmersFarms.Any(fm => fm.FarmerId == farmerId))
				.Select(f => new AddProductFarmOptions()
				{
					Id = f.Id,
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
				.Select(f => new AddProductFarmOptions()
				{
					Id = f.Id,
					Name = f.Name,
					Address = f.Address,
					City = f.City,
					ImageUrl = f.ImageUrl,
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
	}
}
