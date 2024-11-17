﻿using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Web.ViewModels.FarmViewModels;
using FarmersMarketApp.Web.ViewModels.ProductViewModels;

namespace FarmersMarketApp.Services.Contracts
{
	public interface IFarmService
	{
		Task<IEnumerable<FarmInfoAdminViewModel>> GetAllFarmsAsync();

		Task<IEnumerable<FarmInfoViewModel>> GetActiveFarmsAsync();

		Task<ICollection<FarmInfoViewModel>?> GetAllFarmsByFarmerIdAsync(string farmerId);

		Task<FarmInfoViewModel?> GetFarmByIdReadOnlyAsync(string id);

		Task<AddFarmViewModel?> GetFarmToEditByIdAsync(string id);

		Task<ICollection<string>?> GetOnlyFarmIdsByFarmerId(string farmerId);

		Task<string> AddNewFarmAsync(AddFarmViewModel model, string farmerId);

		Task<bool> EditFarmAsync(AddFarmViewModel model);

		Task<IEnumerable<AddProductFarmOptions>?> GetFarmNameAndIdForNewProductAsync(string farmerId);
		Task<IEnumerable<AddProductFarmOptions>> GetThreeRandomFarmsForIndexCarousel();

		Task<IEnumerable<Farm>> GetAllFarmsByFarmerIdForDeletion(string farmerId);

		Task<bool> SetFarmIsDeletedByFarmIdAsync(string farmId);

		Task<bool> RestoreFarmByFarmIdAsync(string farmId);
	}
}
