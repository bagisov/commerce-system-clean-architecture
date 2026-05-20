using CommerceSystem.Application.Interfaces;
using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Domain.Entities;
using CommerceSystem.Infrastructure.Persistence;
using CommerceSystem.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<ISubCompanyRepository, SubCompanyRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IBrandSubCompanyHistoryRepository, BrandSubCompanyHistoryRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<IProductModelRepository, ProductModelRepository>();
            services.AddScoped<IProductVariantRepository, ProductVariantRepository>();
            services.AddScoped<IBranchProductVariantRepository, BranchProductVariantRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IStockBatchRepository, StockBatchRepository>();
            services.AddScoped<IStockMovementRepository, StockMovementRepository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<CommerceDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
