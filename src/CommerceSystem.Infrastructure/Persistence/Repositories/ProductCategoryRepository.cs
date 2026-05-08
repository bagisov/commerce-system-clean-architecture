using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly CommerceDbContext _context;

        public ProductCategoryRepository(CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.ProductCategories.AnyAsync(c => c.Name == name);
        }

        public async Task AddAsync(ProductCategory productCategory)
        {
            await _context.ProductCategories.AddAsync(productCategory);
        }

        public async Task<List<ProductCategory>> GetAllAsync()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory?> GetByIdAsync(Guid id)
        {
            return await _context.ProductCategories
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteAsync(ProductCategory category)
        {
            _context.ProductCategories.Remove(category);
        }
    }
}
