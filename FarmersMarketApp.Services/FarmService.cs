using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.ViewModels.FarmViewModels;
using Microsoft.EntityFrameworkCore;

namespace FarmersMarketApp.Services
{
	public class FarmService : IFarmService
	{
		private readonly IRepository repository;
		public FarmService(IRepository repository)
		{
			this.repository = repository;
		}
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
					IsOpen = f.IsOpen,
					FarmersFarms = f.FarmersFarms,
					Products = f.Products,
				})
				.ToListAsync();
		}

		public async Task<FarmInfoViewModel?> GetFarmByIdAsync(Guid id)
		{
			var farm = await repository
				.AllAsync<Farm>()
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
				CloseHours = farm.CloseHours.ToString(),
				OpenHours = farm.OpenHours.ToString(),
				Email = farm.Email,
				ImageUrl = farm.ImageUrl,
				IsOpen = farm.IsOpen,
				FarmersFarms = farm.FarmersFarms,
				Products = farm.Products,
			};

			return model;
		}

		public async Task<IEnumerable<FarmInfoViewModel>> GetFarmsByFarmerIdAsync(Guid farmerId)
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
					IsOpen = f.IsOpen,
					FarmersFarms = f.FarmersFarms,
					Products = f.Products,
				})
				.ToListAsync();

			return farms;
		}
	}
}
