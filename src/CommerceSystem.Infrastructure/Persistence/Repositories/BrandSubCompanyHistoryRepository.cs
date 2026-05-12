using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Repositories
{
    public class BrandSubCompanyHistoryRepository : IBrandSubCompanyHistoryRepository
    {
        private readonly CommerceDbContext _context;

        public BrandSubCompanyHistoryRepository(CommerceDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(BrandSubCompanyHistory history, CancellationToken cancellationToken)
        {
            await _context.BrandSubCompanyHistories.AddAsync(history, cancellationToken);
        }

        public async Task<List<BrandSubCompanyHistory>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return  await _context.BrandSubCompanyHistories
                .Include(x=> x.SubCompany)
                .Include(x => x.Brand)
                .Where(x=> x.BrandId == id)
                .OrderByDescending(x=> x.LeftAtUtc)
                .ToListAsync(cancellationToken);
        }
    }
}
