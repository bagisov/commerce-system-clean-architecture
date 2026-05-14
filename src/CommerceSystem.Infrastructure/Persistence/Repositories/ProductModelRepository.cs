using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Repositories
{
    using CommerceSystem.Application.Interfaces.Repositories;
    using CommerceSystem.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ProductModelRepository : IProductModelRepository
    {
        private readonly CommerceDbContext _context;

        public ProductModelRepository(CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.ProductModels
                .Include(x => x.Brand)
                .Include(x => x.Category)
                .OrderBy(x => x.Name)
                .ToListAsync(cancellationToken);
        }

        public async Task<ProductModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.ProductModels
                .Include(x => x.Brand)
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task AddAsync(ProductModel productModel, CancellationToken cancellationToken)
        {
            await _context.ProductModels.AddAsync(productModel, cancellationToken);
        }

        public async Task<bool> ExistsByNameAsync(Guid brandId, Guid categoryId, string name, CancellationToken cancellationToken)
        {
            return await _context.ProductModels
                .AnyAsync(x =>
                    x.BrandId == brandId &&
                    x.CategoryId == categoryId &&
                    x.Name.ToLower() == name.ToLower(),
                    cancellationToken);
        }
    }
}
