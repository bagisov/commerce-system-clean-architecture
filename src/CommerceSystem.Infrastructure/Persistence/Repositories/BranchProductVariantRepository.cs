using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Common;
using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Repositories
{
    public class BranchProductVariantRepository : IBranchProductVariantRepository
    {
        private readonly CommerceDbContext _context;

        public BranchProductVariantRepository(CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(Guid branchId, Guid productVariantId, CancellationToken cancellationToken)
        {
            return await _context.BranchProductVariants.AnyAsync(x =>
                x.BranchId == branchId && x.ProductVariantId == productVariantId, cancellationToken);
        }

        public async Task AddAsync(BranchProductVariant branchProductVariant, CancellationToken cancellationToken)
        {
            await _context.BranchProductVariants.AddAsync(branchProductVariant, cancellationToken);
        }

        public async Task<List<BranchProductVariant>> SearchAsync(Guid? branchId, Guid? productVariantId, EntityStatus? status, CancellationToken cancellationToken)
        {
            var query = _context.BranchProductVariants
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

            if (productVariantId.HasValue)
            {
                query = query.Where(x => x.ProductVariantId == productVariantId.Value);
            }

            if (status.HasValue)
            {
                query = query.Where(x => x.Status == status.Value);
            }

            return await query
                .OrderBy(x => x.Branch.Name)
                .ThenBy(x => x.ProductVariant.ProductModel.Name)
                .ToListAsync(cancellationToken);
        }
    }
}
