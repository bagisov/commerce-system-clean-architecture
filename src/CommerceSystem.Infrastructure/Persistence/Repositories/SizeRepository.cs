using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Repositories
{
    public class SizeRepository : ISizeRepository
    {
        private readonly CommerceDbContext _context;

        public SizeRepository(CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Size>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Sizes
                .OrderBy(x => x.SortOrder)
                .ToListAsync(cancellationToken);
        }
    }
}
