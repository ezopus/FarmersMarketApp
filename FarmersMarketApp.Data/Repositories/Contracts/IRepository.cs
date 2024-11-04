namespace FarmersMarketApp.Infrastructure.Repositories.Contracts
{
    public interface IRepository
    {
        IQueryable<T> AllAsync<T>() where T : class;

        IQueryable<T> AllReadOnly<T>() where T : class;

        Task AddAsync<T>(T entity) where T : class;

        Task<int> SaveChangesAsync();

        Task<T?> GetByIdAsync<T>(object id) where T : class;

        Task DeleteAsync<T>(object id) where T : class;
    }
}
