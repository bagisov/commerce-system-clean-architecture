using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence
{
    public class CommerceDbContext : DbContext
    {
        public CommerceDbContext(DbContextOptions<CommerceDbContext> options)  : base( options) { }

        public DbSet<SubCompany> SubCompanies { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchProductVariant> BranchProductVariants { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<BrandSubCompanyHistory> BrandSubCompanyHistories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<StockBatch> StockBatches { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
