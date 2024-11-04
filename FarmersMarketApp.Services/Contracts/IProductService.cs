namespace FarmersMarketApp.Services.Contracts
{
    public interface IProductService
    {
        Task GetProductsAsync<T>();

    }
}
