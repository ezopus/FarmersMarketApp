using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FarmersMarketApp.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly IRepository repository;
		public CategoryService(IRepository repository)
		{
			this.repository = repository;
		}
		public async Task<List<Category>> GetCategoriesAsync()
		{
			return await repository
				.AllReadOnly<Category>()
				.ToListAsync();
		}
	}
}
