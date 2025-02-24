using IKEA.DAL.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IKEA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure
            //builder.Services.AddScoped<ApplicationDbContext>();
            //builder.Services.AddScoped<DbContextOptions<ApplicationDbContext>>(ServiceProvider
            //                            => new DbContextOptionsBuilder<ApplicationDbContext>()
            //                            .UseSqlServer(@"Data Source =.\SQLEXPRESS;Initial Catalog=IKEADB;Integrated Security=True;")
            //                            .Options);

            builder.Services.AddDbContext<ApplicationDbContext>(
                OptionsBuilder =>
                OptionsBuilder.
                UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

                );
            #endregion

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
