using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.ViewModels.ProductViewModels;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static FarmersMarketApp.Common.DataValidation.ValidationConstants;

namespace FarmersMarketApp.Services
{
	public class ProductService : IProductService
	{
		private readonly IRepository repository;
		public ProductService(IRepository repository)
		{
			this.repository = repository;
		}

		//get all products
		public async Task<IEnumerable<ProductInfoViewModel>> GetProductsAsync()
		{
			return await repository
				.AllAsync<Product>()
				.Select(p => new ProductInfoViewModel()
				{
					Id = p.Id.ToString(),
					Name = p.Name,
					Description = p.Description,
					FarmId = p.FarmId.ToString(),
					Farm = p.Farm,
					FarmerId = p.FarmerId.ToString(),
					Farmer = p.Farmer,
					CategoryId = p.CategoryId,
					Price = p.Price,
					DiscountPercentage = p.DiscountPercentage ?? 0,
					UnitType = p.UnitType.ToString(),
					Size = p.Size,
					Quantity = p.Quantity,
					Origin = p.Origin ?? "",
					ImageUrl = p.ImageUrl ?? "",
					ProductionDate = p.ProductionDate.ToString("dd-MM-yyyy"),
					ExpirationDate = p.ProductionDate.ToString("dd-MM-yyyy"),
				})
				.ToListAsync();
		}

		//get one product by id
		public async Task<ProductInfoViewModel?> GetProductByIdAsync(Guid id)
		{
			var product = await repository
				.AllAsync<Product>()
				.FirstOrDefaultAsync(pr => pr.Id == id);

			if (product == null)
			{
				return null;
			}

			var model = new ProductInfoViewModel()
			{
				Id = product.Id.ToString(),
				Name = product.Name,
				Description = product.Description,
				FarmId = product.FarmId.ToString(),
				Farm = product.Farm,
				FarmerId = product.FarmerId.ToString(),
				Farmer = product.Farmer,
				CategoryId = product.CategoryId,
				Price = product.Price,
				DiscountPercentage = product.DiscountPercentage ?? 0,
				UnitType = product.UnitType.ToString(),
				Size = product.Size,
				Quantity = product.Quantity,
				Origin = product.Origin ?? "",
				ImageUrl = product.ImageUrl ?? "",
				ProductionDate = product.ProductionDate.ToString("dd-MM-yyyy"),
				ExpirationDate = product.ProductionDate.ToString("dd-MM-yyyy"),
			};

			return model;
		}

		//TODO: Implement correctly
		public async Task<Product?> GetProductByNameAsync(string name)
		{
			return await repository.AllAsync<Product>().FirstOrDefaultAsync(pr => pr.Name == name);
		}

		//get all products made by specific farmer
		public async Task<IEnumerable<ProductInfoViewModel>> GetProductsByFarmerIdAsync(Guid farmerId)
		{
			return await repository
				.AllAsync<Product>()
				.Where(pr => pr.Farmer.Id == farmerId)
				.Select(pr => new ProductInfoViewModel()
				{
					Id = pr.Id.ToString(),
					Name = pr.Name,
					Description = pr.Description,
					FarmId = pr.FarmId.ToString(),
					Farm = pr.Farm,
					FarmerId = pr.FarmerId.ToString(),
					Farmer = pr.Farmer,
					CategoryId = pr.CategoryId,
					Price = pr.Price,
					DiscountPercentage = pr.DiscountPercentage ?? 0,
					UnitType = pr.UnitType.ToString(),
					Size = pr.Size,
					Quantity = pr.Quantity,
					Origin = pr.Origin ?? "",
					ImageUrl = pr.ImageUrl ?? "",
					ProductionDate = pr.ProductionDate.ToString("dd-MM-yyyy"),
					ExpirationDate = pr.ProductionDate.ToString("dd-MM-yyyy"),
				})
				.ToListAsync();
		}

		//get all products made at specific farm
		public async Task<IEnumerable<ProductInfoViewModel>> GetProductsByFarmIdAsync(Guid farmId)
		{
			return await repository
				.AllAsync<Product>()
				.Where(pr => pr.Farm.Id == farmId)
				.Select(pr => new ProductInfoViewModel()
				{
					Id = pr.Id.ToString(),
					Name = pr.Name,
					Description = pr.Description,
					FarmId = pr.FarmId.ToString(),
					Farm = pr.Farm,
					FarmerId = pr.FarmerId.ToString(),
					Farmer = pr.Farmer,
					CategoryId = pr.CategoryId,
					Price = pr.Price,
					DiscountPercentage = pr.DiscountPercentage ?? 0,
					UnitType = pr.UnitType.ToString(),
					Size = pr.Size,
					Quantity = pr.Quantity,
					Origin = pr.Origin ?? "",
					ImageUrl = pr.ImageUrl ?? "",
					ProductionDate = pr.ProductionDate.ToString("dd-MM-yyyy"),
					ExpirationDate = pr.ProductionDate.ToString("dd-MM-yyyy"),
				})
				.ToListAsync();
		}

		//get all products from specific category
		public async Task<IEnumerable<ProductInfoViewModel>> GetProductsByCategoryIdAsync(int categoryId)
		{
			return await repository
				.AllAsync<Product>()
				.Where(pr => pr.CategoryId == categoryId)
				.Select(pr => new ProductInfoViewModel()
				{
					Id = pr.Id.ToString(),
					Name = pr.Name,
					Description = pr.Description,
					FarmId = pr.FarmId.ToString(),
					Farm = pr.Farm,
					FarmerId = pr.FarmerId.ToString(),
					Farmer = pr.Farmer,
					CategoryId = pr.CategoryId,
					Price = pr.Price,
					DiscountPercentage = pr.DiscountPercentage ?? 0,
					UnitType = pr.UnitType.ToString(),
					Size = pr.Size,
					Quantity = pr.Quantity,
					Origin = pr.Origin ?? "",
					ImageUrl = pr.ImageUrl ?? "",
					ProductionDate = pr.ProductionDate.ToString("dd-MM-yyyy"),
					ExpirationDate = pr.ProductionDate.ToString("dd-MM-yyyy"),
				})
				.ToListAsync(); ;
		}

		public async Task<Guid?> CreateProductAsync(AddProductViewModel model)
		{
			var newProduct = new Product
			{
				Id = Guid.NewGuid(),
				Name = model.Name,
				Description = model.Description,
				UnitType = Enum.Parse<UnitType>(model.UnitType),
				Size = model.Size,
				Quantity = model.Quantity,
				NetWeight = model.NetWeight,
				ShippingWeight = model.ShippingWeight,
				Season = Enum.TryParse<Season>(model.Season, true, out Season result)
					? result
					: null,
				ProductionDate = DateTime.ParseExact(model.ProductionDate, DateTimeRequiredFormat,
					CultureInfo.CurrentCulture),
				ExpirationDate = DateTime.ParseExact(model.ExpirationDate, DateTimeRequiredFormat,
					CultureInfo.CurrentCulture),
				CategoryId = model.CategoryId,
				Price = model.Price,
				HasDiscount = model.DiscountPercentage > 0 ? true : false,
				DiscountPercentage = (decimal)model.DiscountPercentage,
				FarmerId = model.FarmerId,
				FarmId = model.FarmId,
				Barcode = model.Barcode,
				ImageUrl = model.ImageUrl,
				Origin = model.Origin,
			};

			await repository.AddAsync(newProduct);
			await repository.SaveChangesAsync();

			return newProduct.Id;
		}
	}
}
