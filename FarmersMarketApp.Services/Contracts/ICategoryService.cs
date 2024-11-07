using FarmersMarketApp.Infrastructure.Data.Models;

namespace FarmersMarketApp.Services.Contracts
{
	public interface ICategoryService
	{
		Task<List<Category>> GetCategoriesAsync();
	}
}
