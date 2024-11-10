using FarmersMarketApp.Infrastructure.Data;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FarmersMarketApp.Infrastructure.Repositories
{
	public class FarmersMarketRepository : IRepository
	{
		private readonly DbContext context;

		public FarmersMarketRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		private DbSet<T> DbSet<T>() where T : class
		{
			return context.Set<T>();
		}

		public IQueryable<T> AllAsync<T>() where T : class
		{
			return DbSet<T>();
		}

		public IQueryable<T> AllReadOnly<T>() where T : class
		{
			return DbSet<T>().AsNoTracking();
		}

		public async Task AddAsync<T>(T entity) where T : class
		{
			await DbSet<T>().AddAsync(entity);
		}

		public async Task<int> SaveChangesAsync()
		{
			return await context.SaveChangesAsync();
		}

		public async Task<T?> GetByIdAsync<T>(object id) where T : class
		{
			return await DbSet<T>().FindAsync(id);
		}

		public async Task DeleteAsync<T>(object id) where T : class
		{
			T? entity = await GetByIdAsync<T>(id);

			if (entity != null)
			{
				DbSet<T>().Remove(entity);
			}
		}

	}
}
