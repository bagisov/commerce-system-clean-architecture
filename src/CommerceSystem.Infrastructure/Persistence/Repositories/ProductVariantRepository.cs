using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Repositories
{
    public class ProductVariantRepository : IProductVariantRepository
    {
        private readonly CommerceDbContext _context;

        public ProductVariantRepository(CommerceDbContext context)
        {
            _context = context;
        }



        public async Task<ProductVariant?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.ProductVariants
                .Include(x => x.ProductModel)
                .Include(x => x.Color)
                .Include(x => x.Size)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<bool> ExistsAsync(
            Guid productModelId,
            Guid colorId,
            Guid sizeId,
            CancellationToken cancellationToken)
        {
            return await _context.ProductVariants.AnyAsync(x =>
                x.ProductModelId == productModelId &&
                x.ColorId == colorId &&
                x.SizeId == sizeId,
                cancellationToken);
        }

        public async Task AddAsync(ProductVariant productVariant, CancellationToken cancellationToken)
        {
            await _context.ProductVariants.AddAsync(productVariant, cancellationToken);
        }
    }
}
