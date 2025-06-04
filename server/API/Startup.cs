using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using StockManagementSystem.Application.Interfaces;
using StockManagementSystem.Application.Mapper;
using StockManagementSystem.Application.Repositories;
using StockManagementSystem.Application.UnitOfWork;
using StockManagementSystem.Application.Validation;
using StockManagementSystem.Infrastructure;
using Swashbuckle.AspNetCore.SwaggerUI;
using Swashbuckle.AspNetCore.Swagger;
using Application.Services;

namespace StockManagementSystem.API;

public class Startup
{
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration) => Configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {


        services.AddControllers()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<CreateStockTypeRequestValidator>();
                });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IStockTypeRepository, StockTypeRepository>();
        services.AddScoped<IStockUnitRepository, StockUnitRepository>();
        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<StockService>();
        services.AddScoped<StockTypeService>();
        services.AddScoped<StockUnitService>();
        services.AddSingleton(new MapperConfiguration(x => x.AddProfile(new MapperConfig())).CreateMapper());

        // Swagger ekle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Swagger middleware
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stock Management API v1");
            c.RoutePrefix = string.Empty; // Swagger UI ana dizinde açılsın
        });

        //app.UseMiddleware<ErrorHandlerMiddleware>();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}