using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Repositories
{
    public class StockBatchRepository : IStockBatchRepository
    {
        private readonly CommerceDbContext _context;

        public StockBatchRepository(CommerceDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(
            StockBatch stockBatch,
            CancellationToken cancellationToken)
        {
            await _context.StockBatches.AddAsync(stockBatch, cancellationToken);
        }
    }
}
