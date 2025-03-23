using IKEA.BLL.Common.Services;
using IKEA.BLL.Services;
using IKEA.DAL.Persistence.Data;
using IKEA.DAL.Persistence.Repositories.Departments;
using IKEA.DAL.Persistence.Repositories.Employees;
using IKEA.DAL.Persistence.UnitOfWork;
using IKEA.Mapping;
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
                OptionsBuilder.UseLazyLoadingProxies().
                UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

                );
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeService>();
            builder.Services.AddAutoMapper(M=>M.AddProfile<MappingProfile>());
            builder.Services.AddTransient<IAttachService, AttachmentService>();
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
