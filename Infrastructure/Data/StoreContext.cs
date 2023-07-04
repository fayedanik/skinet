using System.Reflection;
using Core.Entities;
using Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductBrand> ProductBrands { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);

            if( Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite" )
            {
                foreach(var enitity in modelBuilder.Model.GetEntityTypes() )
                {
                    var properties = enitity.ClrType.GetProperties()
                        .Where(p => p.PropertyType == typeof(decimal));
                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(enitity.Name).Property(property.Name).HasConversion<double>();
                    }
                }
            }
        }
    }
}
