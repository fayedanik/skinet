using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context,ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.ProductBrands.Any())
                {
                    var path = "../Infrastructure/Data/SeedData/brands.json";
                    if (!File.Exists(path)) return;
                    var brandsData = File.ReadAllText(path);
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    if( brands is not null )
                    {
                        foreach (var brand in brands)
                        {
                            if (brand is not null)
                            {
                                context.ProductBrands.Add(brand);
                            }
                        }
                        await context.SaveChangesAsync();
                    }
                    
                }

                if(!context.ProductTypes.Any())
                {
                    var path = "../Infrastructure/Data/SeedData/types.json";
                    if (!File.Exists(path)) return;
                    var productTypesData = File.ReadAllText(path);
                    var types = JsonSerializer.Deserialize<List<ProductType>>(productTypesData);
                    if( types is not null )
                    {
                        foreach (var type in types)
                        {
                            if (type is not null)
                            {
                                context.ProductTypes.Add(type);
                            }
                        }
                        await context.SaveChangesAsync();
                    }    
                    
                }

                if (!context.Products.Any())
                {
                    var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);
                    if (products is not null)
                    {
                        foreach (var product in products)
                        {
                            if (product is not null)
                            {
                                context.Products.Add(product);
                            }
                        }
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
