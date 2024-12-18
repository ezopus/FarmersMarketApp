﻿using FarmersMarketApp.Common.Enums;
using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.ViewModels.FarmViewModels;
using FarmersMarketApp.ViewModels.ProductViewModels;
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
		public async Task<ProductsQueryModel> GetAllProductsAsync(int? categoryId,
			string? farmId,
			string? farmerId,
			string? searchTerm,
			ProductSorting sorting = ProductSorting.Newest,
			int currentPage = 1,
			int productsPerPage = 8)
		{
			var productsToShow = repository
				.AllReadOnly<Product>();

			//check if category is included in search
			if (categoryId != null)
			{
				productsToShow = productsToShow.Where(pr => pr.CategoryId == categoryId);
			}

			//check if search input field is empty
			if (!string.IsNullOrEmpty(searchTerm))
			{
				string normalizedSearchTerm = searchTerm.ToLower().Trim();
				productsToShow = productsToShow
					.Where(pr => pr.Name.ToLower().Contains(normalizedSearchTerm));
			}

			//check if specific farm is picked
			if (!string.IsNullOrEmpty(farmId))
			{
				productsToShow = productsToShow
					.Where(pr => pr.FarmId.ToString().ToLower() == farmId.ToLower());
			}

			//check if specific farmer is picked
			if (!string.IsNullOrEmpty(farmerId))
			{
				productsToShow = productsToShow
					.Where(pr => pr.Farm.FarmersFarms.Any(f => f.FarmerId == Guid.Parse(farmerId)));
			}

			//sort results
			productsToShow = sorting switch
			{
				ProductSorting.PriceAscending => productsToShow.OrderBy(pr => pr.Price),
				ProductSorting.PriceDescending => productsToShow.OrderByDescending(pr => pr.Price),
				ProductSorting.Newest => productsToShow.OrderByDescending(pr => pr.DateAdded),
				ProductSorting.Oldest => productsToShow.OrderBy(pr => pr.DateAdded),
				_ => productsToShow
			};

			//take products to visualize
			var products = await productsToShow
				.Select(pr => new ProductInfoViewModel()
				{
					Id = pr.Id.ToString(),
					Name = pr.Name,
					Description = pr.Description,
					FarmId = pr.FarmId.ToString(),
					Farm = new FarmInfoViewModel()
					{
						Id = pr.Farm.Id.ToString(),
						Name = pr.Farm.Name,
						Address = pr.Farm.Address,
						City = pr.Farm.City,
					},

					CategoryId = pr.CategoryId,
					Price = pr.Price,
					DiscountPercentage = pr.DiscountPercentage ?? 0,
					UnitType = pr.UnitType.ToString(),
					Quantity = pr.Quantity,
					Origin = pr.Origin ?? "",
					ImageUrl = pr.ImageUrl ?? "",
					ProductionDate = pr.ProductionDate.ToString(DateTimeRequiredFormat),
					ExpirationDate = pr.ExpirationDate.ToString(DateTimeRequiredFormat),
					DateAdded = pr.DateAdded.ToString(DateTimeRequiredFormat),
					IsDeleted = pr.IsDeleted,
				})
				.ToListAsync();

			//return filtered and paginated results to controller
			return new ProductsQueryModel()
			{
				Products = products,
				TotalProducts = await productsToShow.CountAsync(),
			};

		}

		public async Task<ProductsQueryModel> GetAllActiveProductsWithQueryAsync(
			int? categoryId,
			string? farmId,
			string? farmerId,
			string? searchTerm,
			ProductSorting sorting = ProductSorting.Newest,
			int currentPage = 1,
			int productsPerPage = 8
			)
		{
			var productsToShow = repository
				.AllReadOnly<Product>()
				.Include(pr => pr.Farm)
				.Where(pr => !pr.IsDeleted);

			//check if category is included in search
			if (categoryId != null)
			{
				productsToShow = productsToShow.Where(pr => pr.CategoryId == categoryId);
			}

			//check if search input field is empty
			if (!string.IsNullOrEmpty(searchTerm))
			{
				string normalizedSearchTerm = searchTerm.ToLower().Trim();
				productsToShow = productsToShow
					.Where(pr => pr.Name.ToLower().Contains(normalizedSearchTerm));
			}

			//check if specific farm is picked
			if (!string.IsNullOrEmpty(farmId))
			{
				productsToShow = productsToShow
					.Where(pr => pr.FarmId.ToString().ToLower() == farmId.ToLower());
			}

			//check if specific farm is picked
			if (!string.IsNullOrEmpty(farmerId))
			{
				productsToShow = productsToShow
					.Where(pr => pr.Farm.FarmersFarms.All(f => f.FarmerId == Guid.Parse(farmerId)));
			}

			//sort results
			productsToShow = sorting switch
			{
				ProductSorting.PriceAscending => productsToShow.OrderBy(pr => pr.Price),
				ProductSorting.PriceDescending => productsToShow.OrderByDescending(pr => pr.Price),
				ProductSorting.Newest => productsToShow.OrderByDescending(pr => pr.DateAdded),
				ProductSorting.Oldest => productsToShow.OrderBy(pr => pr.DateAdded),
				ProductSorting.DiscountedFirst => productsToShow.OrderByDescending(pr => pr.HasDiscount).ThenByDescending(pr => pr.DiscountPercentage),
				_ => productsToShow
			};

			//take products to visualize
			var products = await productsToShow
				.Skip((currentPage - 1) * productsPerPage)
				.Take(productsPerPage)
				.Select(pr => new ProductInfoViewModel()
				{
					Id = pr.Id.ToString(),
					Name = pr.Name,
					Description = pr.Description,
					FarmId = pr.FarmId.ToString(),
					Farm = new FarmInfoViewModel()
					{
						Id = pr.Farm.Id.ToString(),
						Name = pr.Farm.Name,
						Address = pr.Farm.Address,
						City = pr.Farm.City,
					},
					CategoryId = pr.CategoryId,
					Price = pr.Price,
					DiscountPercentage = pr.DiscountPercentage ?? 0,
					UnitType = pr.UnitType.ToString(),
					Quantity = pr.Quantity,
					Origin = pr.Origin ?? "",
					ImageUrl = pr.ImageUrl ?? "",
					ProductionDate = pr.ProductionDate.ToString(DateTimeRequiredFormat),
					ExpirationDate = pr.ExpirationDate.ToString(DateTimeRequiredFormat),
					DateAdded = pr.DateAdded.ToString(DateTimeRequiredFormat)
				})
				.ToListAsync();

			//return filtered and paginated results to controller
			return new ProductsQueryModel()
			{
				Products = products,
				TotalProducts = await productsToShow.CountAsync(),
			};
		}

		//get one product by id
		public async Task<ProductInfoViewModel?> GetProductByIdAsync(string id)
		{
			var product = await repository
				.AllReadOnly<Product>()
				.FirstOrDefaultAsync(pr => pr.Id == Guid.Parse(id));

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
				CategoryId = product.CategoryId,
				Price = product.Price,
				DiscountPercentage = product.DiscountPercentage ?? 0,
				UnitType = product.UnitType.ToString(),
				Quantity = product.Quantity,
				Origin = product.Origin ?? "",
				ImageUrl = product.ImageUrl ?? "",
				ProductionDate = product.ProductionDate.ToString("dd-MM-yyyy"),
				ExpirationDate = product.ExpirationDate.ToString("dd-MM-yyyy"),
				IsDeleted = product.IsDeleted,
				DateAdded = product.DateAdded.ToString(DateTimeRequiredFormat)
			};

			return model;
		}

		//get one product by id to be edited
		public async Task<AddProductViewModel?> GetProductToEditByIdAsync(string id)
		{
			var product = await repository
				.All<Product>()
				.Where(p => !p.IsDeleted)
				.FirstOrDefaultAsync(pr => pr.Id == Guid.Parse(id));

			if (product == null)
			{
				return null;
			}

			var model = new AddProductViewModel()
			{
				Id = product.Id.ToString(),
				Name = product.Name,
				Description = product.Description,
				ImageUrl = product.ImageUrl ?? "",
				UnitType = product.UnitType.ToString(),
				Quantity = product.Quantity,
				NetWeight = product.NetWeight,
				Season = product.Season.ToString(),
				ProductionDate = product.ProductionDate.ToString("dd-MM-yyyy"),
				ExpirationDate = product.ExpirationDate.ToString("dd-MM-yyyy"),
				CategoryId = product.CategoryId,
				Price = product.Price,
				DiscountPercentage = product.DiscountPercentage ?? 0,
				Barcode = product.Barcode ?? "",
				Origin = product.Origin ?? "",
				FarmId = product.FarmId.ToString(),

			};

			return model;
		}

		public async Task<bool?> UpdateEditedProductAsync(AddProductViewModel model, string? newFilePath)
		{
			var productToEdit = await repository
				.GetByIdAsync<Product>(Guid.Parse(model.Id));

			if (productToEdit == null || productToEdit.IsDeleted)
			{
				return false;
			}

			//delete old file
			if (!string.IsNullOrEmpty(newFilePath) && !string.IsNullOrEmpty(productToEdit.ImageUrl))
			{
				var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", productToEdit.ImageUrl.TrimStart('/'));
				File.Delete(oldFilePath);
			}

			try
			{
				productToEdit.Name = model.Name;
				productToEdit.Description = model.Description;
				productToEdit.UnitType = Enum.Parse<UnitType>(model.UnitType);
				productToEdit.Quantity = model.Quantity;
				productToEdit.NetWeight = model.NetWeight;
				productToEdit.Season = !string.IsNullOrEmpty(model.Season)
						? Enum.Parse<Season>(model.Season)
						: null;
				productToEdit.CategoryId = model.CategoryId;
				productToEdit.Price = model.Price;
				productToEdit.DiscountPercentage = model.DiscountPercentage;
				productToEdit.Origin = model.Origin ?? "";
				productToEdit.ImageUrl = string.IsNullOrEmpty(newFilePath)
					? productToEdit.ImageUrl
					: newFilePath;
				productToEdit.ProductionDate = DateTime.ParseExact(model.ProductionDate,
					DateTimeRequiredFormat, CultureInfo.InvariantCulture);
				productToEdit.ExpirationDate = DateTime.ParseExact(model.ExpirationDate,
					DateTimeRequiredFormat, CultureInfo.InvariantCulture);
				productToEdit.FarmId = Guid.Parse(model.FarmId);
			}
			catch
			{
				return false;
			}

			await repository.SaveChangesAsync();
			return true;
		}

		//get all products made by specific farmer
		public async Task<IEnumerable<ProductInfoViewModel>?> GetFarmerProductsByFarmerIdAsync(string farmerId)
		{
			if (string.IsNullOrEmpty(farmerId))
			{
				return null;
			}

			var products = await repository
			   .All<Product>()
			   .Include(pr => pr.Farm)
			   .Include(pr => pr.Farm.FarmersFarms)
			   .Where(pr => pr.Farm.FarmersFarms.All(fr => fr.FarmerId == Guid.Parse(farmerId)))
			   .ToListAsync();

			var returnProducts = products
		   .Select(pr => new ProductInfoViewModel()
		   {
			   Id = pr.Id.ToString(),
			   Name = pr.Name,
			   Description = pr.Description,
			   FarmId = pr.FarmId.ToString(),
			   Farm = new FarmInfoViewModel()
			   {
				   Id = pr.Farm.Id.ToString(),
				   Name = pr.Farm.Name,
				   Address = pr.Farm.Address,
				   City = pr.Farm.City,
			   },
			   CategoryId = pr.CategoryId,
			   Price = pr.Price,
			   DiscountPercentage = pr.DiscountPercentage ?? 0,
			   UnitType = pr.UnitType.ToString(),
			   Quantity = pr.Quantity,
			   Origin = pr.Origin ?? "",
			   ImageUrl = pr.ImageUrl ?? "",
			   ProductionDate = pr.ProductionDate.ToString(DateTimeRequiredFormat),
			   ExpirationDate = pr.ExpirationDate.ToString(DateTimeRequiredFormat),
			   IsDeleted = pr.IsDeleted,
			   DateAdded = pr.DateAdded.ToString(DateTimeRequiredFormat),
		   })
		   .ToList();

			return returnProducts;
		}

		//create new product
		public async Task<string?> CreateProductAsync(AddProductViewModel model)
		{
			try
			{
				var newProduct = new Product
				{
					Id = Guid.NewGuid(),
					Name = model.Name,
					Description = model.Description,
					UnitType = Enum.Parse<UnitType>(model.UnitType),
					Quantity = model.Quantity,
					NetWeight = model.NetWeight,
					Season = Enum.TryParse(model.Season, true, out Season result)
				  ? result
				  : null,
					ProductionDate = DateTime.ParseExact(model.ProductionDate, DateTimeRequiredFormat,
				  CultureInfo.CurrentCulture),
					ExpirationDate = DateTime.ParseExact(model.ExpirationDate, DateTimeRequiredFormat,
				  CultureInfo.CurrentCulture),
					CategoryId = model.CategoryId,
					Price = model.Price,
					HasDiscount = model.DiscountPercentage > 0,
					DiscountPercentage = model.DiscountPercentage,
					FarmId = Guid.Parse(model.FarmId),
					Barcode = model.Barcode,
					ImageUrl = model.ImageUrl,
					Origin = model.Origin,
					DateAdded = DateTime.Now,
				};

				await repository.AddAsync(newProduct);
				await repository.SaveChangesAsync();

				return newProduct.Id.ToString();
			}
			catch (Exception e)
			{
				return null;
			}
		}

		//get product for populating order details
		public async Task<Product?> GetProductForOrderByProductIdAsync(string productId)
		{
			return await repository
				.AllReadOnly<Product>()
				.Where(pr => !pr.IsDeleted)
				.FirstOrDefaultAsync(pr => pr.Id == Guid.Parse(productId));
		}

		public async Task<IEnumerable<Product>> GetProductsForDeletionByFarmIdAsync(string farmId)
		{
			return await repository.All<Product>()
				.Where(p => p.FarmId == Guid.Parse(farmId))
				.ToListAsync();
		}
		public async Task<IEnumerable<Product>> GetProductsForDeletionByFarmerIdAsync(string farmerId)
		{
			return await repository.All<Product>()
				.Where(p => p.Farm.FarmersFarms
					.Any(ff => ff.FarmerId == Guid.Parse(farmerId)))
				.ToListAsync();
		}

		//set product Is Deleted to true
		public async Task<bool> SetProductIsDeletedByIdAsync(string productId)
		{
			var productToDelete = await repository.GetByIdAsync<Product>(Guid.Parse(productId));

			if (productToDelete == null)
			{
				return false;
			}

			productToDelete.IsDeleted = true;
			await repository.SaveChangesAsync();

			return true;
		}

		//restore product by id
		public async Task<bool> RestoreProductByIdAsync(string productId)
		{
			var productToDelete = await repository.GetByIdAsync<Product>(Guid.Parse(productId));

			if (productToDelete == null)
			{
				return false;
			}

			productToDelete.IsDeleted = false;
			await repository.SaveChangesAsync();

			return true;
		}

		//get farmer pra ooducts when gathering products to visualize for each farmer in his own individual orders
		public async Task<IEnumerable<ProductFarmerOrderViewModel>> GetFarmerProductOrdersByOrderIdAsync(string farmerId, string orderId, ICollection<string> farmerFarms)
		{
			var products = new List<ProductFarmerOrderViewModel>();

			foreach (var farm in farmerFarms)
			{
				var farmProducts = await repository
					.AllReadOnly<ProductOrder>()
					.Where(o => o.OrderId == Guid.Parse(orderId)
						&& o.FarmId == Guid.Parse(farm))
					.Select(po => new ProductFarmerOrderViewModel()
					{
						ProductName = po.Product.Name,
						ProductPriceAtPurchase = po.ProductPriceAtTimeOfOrder,
						ProductQuantity = po.ProductQuantity,
					})
					.ToListAsync();

				products.AddRange(farmProducts);
			}

			return products;
		}
	}
}
