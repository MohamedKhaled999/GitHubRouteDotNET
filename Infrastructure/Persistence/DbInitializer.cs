using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence
{
    public class DbInitializer : IDbInitializer
    {
        private readonly StoreContext _storeContext;

        public DbInitializer(StoreContext storeContext ) 
        {
            _storeContext = storeContext;
        }
        public async Task Initialize()
        {

            try
            {
                if (_storeContext.Database.GetPendingMigrations().Any())
                    _storeContext.Database.Migrate();

                if (!_storeContext.ProductTypes.Any())
                {
                    var typesData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seeding\types.json");

                    var types = JsonSerializer.Deserialize<List<Type>>(typesData);

                    if (types is not null && types.Any())
                    {
                        await _storeContext.AddRangeAsync(types);
                        await _storeContext.SaveChangesAsync();

                    }
                }

                if (!_storeContext.ProductBrands.Any())
                {
                    var brandsData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seeding\brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    if (brands is not null && brands.Any())
                    {
                        await _storeContext.AddRangeAsync(brands);
                        await _storeContext.SaveChangesAsync();
                    }

                }


                if (!_storeContext.Products.Any())
                {
                    var ProductsData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seeding\products.json");
                    var Products = JsonSerializer.Deserialize<List<ProductBrand>>(ProductsData);

                    if (Products is not null && Products.Any())
                    {
                        await _storeContext.AddRangeAsync(Products);
                        await _storeContext.SaveChangesAsync();
                    }

                }


            }
            catch (Exception)
            {

                throw;
            }
        

        }
    }
}
