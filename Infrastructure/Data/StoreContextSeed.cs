using System;
using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
	public class StoreContextSeed
	{
		public static async Task SeedAsync(StoreContext context)
		{
			
			if( !context.ProductBrands.Any() )
			{
                var path = "../Infrastructure/Data/SeedData/brands.json";
                var isExist = File.Exists(path);
                if (!isExist) return;
                var productBrandsData = await File.ReadAllTextAsync(path);
                var products = JsonSerializer.Deserialize<List<ProductBrand>>(productBrandsData);
                context.AddRange(products ?? new List<ProductBrand>());
            }

            if (!context.ProductTypes.Any())
            {
                var path = "../Infrastructure/Data/SeedData/types.json";
                var isExist = File.Exists(path);
                if (!isExist) return;
                var productTypesData = await File.ReadAllTextAsync(path);
                var products = JsonSerializer.Deserialize<List<ProductType>>(productTypesData);
                context.AddRange(products ?? new List<ProductType>());
            }

            if (!context.Products.Any())
            {
                var path = "../Infrastructure/Data/SeedData/products.json";
                var isExist = File.Exists(path);
                if (!isExist) return;
                var productData = await File.ReadAllTextAsync(path);
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                context.AddRange(products ?? new List<Product>());
            }

            if( context.ChangeTracker.HasChanges() )
            {
                await context.SaveChangesAsync();
            }

        }
	}
}

