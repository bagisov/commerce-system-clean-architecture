using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly CommerceDbContext _context;

        public StockRepository(CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Stock>> SearchAsync(
            Guid? branchId,
            Guid? brandId,
            Guid? categoryId,
            Guid? productModelId,
            Guid? productVariantId,
            string? searchText,
            CancellationToken cancellationToken)
        {
            var query = _context.Stocks
                .Include(x => x.Branch)
                .Include(x => x.ProductVariant)
                    .ThenInclude(x => x.ProductModel)
                        .ThenInclude(x => x.Brand)
                .Include(x => x.ProductVariant)
                    .ThenInclude(x => x.ProductModel)
                        .ThenInclude(x => x.Category)
                .Include(x => x.ProductVariant)
                    .ThenInclude(x => x.Color)
                .Include(x => x.ProductVariant)
                    .ThenInclude(x => x.Size)
                .AsQueryable();

            if (branchId.HasValue)
            {
                query = query.Where(x => x.BranchId == branchId.Value);
            }

            if (brandId.HasValue)
            {
                query = query.Where(x => x.ProductVariant.ProductModel.BrandId == brandId.Value);
            }

            if (categoryId.HasValue)
            {
                query = query.Where(x => x.ProductVariant.ProductModel.CategoryId == categoryId.Value);
            }

            if (productModelId.HasValue)
            {
                query = query.Where(x => x.ProductVariant.ProductModelId == productModelId.Value);
            }

            if (productVariantId.HasValue)
            {
                query = query.Where(x => x.ProductVariantId == productVariantId.Value);
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
                        x.Branch.Name.ToLower().Contains(word) ||
                        x.ProductVariant.ProductModel.Name.ToLower().Contains(word) ||
                        x.ProductVariant.ProductModel.Brand.Name.ToLower().Contains(word) ||
                        x.ProductVariant.ProductModel.Category.Name.ToLower().Contains(word) ||
                        (x.ProductVariant.Color != null &&
                         x.ProductVariant.Color.Name.ToLower().Contains(word)) ||
                        (x.ProductVariant.Size != null &&
                         x.ProductVariant.Size.Name.ToLower().Contains(word)));
                }
            }

            return await query
                .OrderBy(x => x.Branch.Name)
                .ThenBy(x => x.ProductVariant.ProductModel.Name)
                .ThenBy(x => x.ProductVariant.Color != null ? x.ProductVariant.Color.Name : "")
                .ThenBy(x => x.ProductVariant.Size != null ? x.ProductVariant.Size.SortOrder : 0)
                .ToListAsync(cancellationToken);
        }

        public async Task<Stock?> GetByBranchAndProductVariantAsync(
            Guid branchId,
            Guid productVariantId,
            CancellationToken cancellationToken)
        {
            return await _context.Stocks
                .FirstOrDefaultAsync(x =>
                    x.BranchId == branchId &&
                    x.ProductVariantId == productVariantId,
                    cancellationToken);
        }

        public async Task AddAsync(
            Stock stock,
            CancellationToken cancellationToken)
        {
            await _context.Stocks.AddAsync(stock, cancellationToken);
        }

        public void Update(Stock stock)
        {
            _context.Stocks.Update(stock);
        }
    }
}
