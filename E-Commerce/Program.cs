
using Domain.Contracts;
using Domain.Entities.Identity;
using E_Commerce.Factories;
using E_Commerce.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using Persistence.Data;
using Persistence.Repositories;
using Services;
using Services.Abstractions;
using Shared.Security;
using StackExchange.Redis;
using System.Text;

namespace E_Commerce
{
    public class Program
    {
        public static async Task   Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped<IDbInitializer, DbInitializer>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddScoped<IBasketRepository, BasketRepository>();
            builder.Services.AddAutoMapper(typeof(Services.AssemblyReference).Assembly);
            builder.Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
            builder.Services.AddIdentity<User, IdentityRole>(op =>
            {
                op.Password.RequireLowercase = false;
                op.Password.RequireNonAlphanumeric = false;
                op.Password.RequireLowercase = false;
                op.Password.RequireDigit = false;
                op.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<StoreIdentityContext>();


            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreContext>
            (
                 op => op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            builder.Services.AddDbContext<StoreIdentityContext>
           (
                op => op.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"))
           );

            builder.Services.AddSingleton<IConnectionMultiplexer>( op =>
                                        ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")) );
            //For Validation
            builder.Services.Configure<ApiBehaviorOptions>(op =>
            {
                op.InvalidModelStateResponseFactory = ApiResponseFactory.CustomValidationErrors;
            });


            //For Authentication

            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
            builder.Services.AddAuthentication(
                op =>
                {
                    op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                ).AddJwtBearer( op =>
                {
                    var jwtOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>();
                    op.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issure,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecertKey)),

                    };
                })
                ;

            var app = builder.Build();
            await InitializeDb(app);
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();

            async Task InitializeDb(WebApplication app)
            {
                var scope = app.Services.CreateScope();
                var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                await dbInitializer.InitializeAsync();
                await dbInitializer.InitializeIdentityAsync();

            }
        
        }

       



    }
}
