using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Repositories
{
    public class ColorRepository : IColorRepository
    {
        private readonly CommerceDbContext _context;

        public ColorRepository(CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Color>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Colors
                .OrderBy(x => x.Name)
                .ToListAsync(cancellationToken);
        }
    }
}
