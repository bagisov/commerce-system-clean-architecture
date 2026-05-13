using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Common;
using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly CommerceDbContext _context;

        public BranchRepository(CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _context.Branches.AnyAsync(x => x.Name == name, cancellationToken);
        }

        public async Task AddAsync(Branch branch, CancellationToken cancellationToken)
        {
            await _context.Branches.AddAsync(branch, cancellationToken);
        }

        public async Task<List<Branch>> GetFilteredAsync( Guid? brandId, EntityStatus? status, string? name, string? address, CancellationToken cancellationToken)
        {
            var query = _context.Branches
                .Include(x => x.Brand)
                .AsQueryable();

            if (brandId.HasValue)
                query = query.Where(x => x.BrandId == brandId.Value);

            if (status.HasValue)
                query = query.Where(x => x.Status == status.Value);

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(x => x.Name.Contains(name));

            if (!string.IsNullOrWhiteSpace(address))
                query = query.Where(x => x.Address.Contains(address));

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Branches
                .Include(x => x.Brand)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Delete(Branch branch)
        {
            _context.Branches.Remove(branch);
        }
    }
}
