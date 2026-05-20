using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Repositories
{
    public class StockMovementRepository : IStockMovementRepository
    {
        private readonly CommerceDbContext _context;

        public StockMovementRepository(CommerceDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(StockMovement stockMovement, CancellationToken cancellationToken)
        {
            await _context.StockMovements.AddAsync(stockMovement, cancellationToken);
        }
    }
}
