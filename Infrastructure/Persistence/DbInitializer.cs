using Domain.Contracts;
using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(StoreContext storeContext ,UserManager<User> userManager ,RoleManager<IdentityRole> roleManager) 
        {
            _storeContext = storeContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task InitializeAsync()
        {

            try
            {
                if (_storeContext.Database.GetPendingMigrations().Any())
                    _storeContext.Database.Migrate();

                if (!_storeContext.ProductTypes.Any())
                {
                    var typesData = await File.ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\Seeding\types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

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
                    var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);

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
        public async Task InitializeIdentityAsync()
        {
            if (!_roleManager.Roles.Any())
            {
                _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));

                _roleManager.CreateAsync(new IdentityRole("Admin"));
            }


            if (!_userManager.Users.Any())
            {
                var superAdmin = new User()
                {
                    DisplayName = "SuperAdmin",
                    Email = "SuperAdmin@gmail.com",
                    UserName = "SuperAdmin",
                    PhoneNumber = "1234567890",

                };
                await  _userManager.CreateAsync(superAdmin, "P@ssw0rd");
                var admin = new User()
                {
                    DisplayName = "SuperAdmin",
                    Email = "SuperAdmin@gmail.com",
                    UserName = "SuperAdmin",
                    PhoneNumber = "1234567890",
                };
                await  _userManager.CreateAsync(admin,"P@ssw0rd");

               //-----------------------------------------* Roles *--------------------------------------------------------------

               await _userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
               await _userManager.AddToRoleAsync(admin, "Admin");

               
            }


        }
    }
}
