using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly CommerceDbContext _context;
        public BrandRepository(CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _context.Brands.AnyAsync(x=> x.Name == name, cancellationToken);
        }

        public async Task AddAsync(Brand brand, CancellationToken cancellationToken)
        {
            await _context.Brands.AddAsync(brand, cancellationToken);
        }

        public async Task<Brand?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Brands.FirstOrDefaultAsync(x=> x.Id == id, cancellationToken);
        }

        public async Task<List<Brand>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Brands.ToListAsync(cancellationToken);
        }
    }
}
