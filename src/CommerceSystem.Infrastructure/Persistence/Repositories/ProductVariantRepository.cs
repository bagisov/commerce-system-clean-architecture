using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Common;
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

        public async Task<List<ProductVariant>> SearchAsync(
            Guid? brandId,
            Guid? categoryId,
            Guid? productModelId,
            List<Guid>? colorIds,
            List<Guid>? sizeIds,
            EntityStatus? status,
            string? searchText,
            CancellationToken cancellationToken)
        {
            var query = _context.ProductVariants
                .Include(x => x.ProductModel)
                    .ThenInclude(x => x.Brand)
                .Include(x => x.ProductModel)
                    .ThenInclude(x => x.Category)
                .Include(x => x.Color)
                .Include(x => x.Size)
                .AsQueryable();

            if (brandId.HasValue)
            {
                query = query.Where(x =>
                    x.ProductModel.BrandId == brandId.Value);
            }

            if (categoryId.HasValue)
            {
                query = query.Where(x =>
                    x.ProductModel.CategoryId == categoryId.Value);
            }

            if (productModelId.HasValue)
            {
                query = query.Where(x =>
                    x.ProductModelId == productModelId.Value);
            }

            if (colorIds is { Count: > 0 })
            {
                query = query.Where(x =>
                    colorIds.Contains(x.ColorId));
            }

            if (sizeIds is { Count: > 0 })
            {
                query = query.Where(x =>
                    sizeIds.Contains(x.SizeId));
            }

            if (status.HasValue)
            {
                query = query.Where(x =>
                    x.Status == status.Value);
            }

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var words = searchText
                    .Trim()
                    .ToLower()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    query = query.Where(x =>
                        x.ProductModel.Name.ToLower().Contains(word) ||
                        x.ProductModel.Brand.Name.ToLower().Contains(word) ||
                        x.ProductModel.Category.Name.ToLower().Contains(word) ||
                        x.Color.Name.ToLower().Contains(word) ||
                        x.Size.Name.ToLower().Contains(word));
                }
            }

            return await query
                .OrderBy(x => x.ProductModel.Name)
                .ThenBy(x => x.Color.Name)
                .ThenBy(x => x.Size.SortOrder)
                .ToListAsync(cancellationToken);
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
