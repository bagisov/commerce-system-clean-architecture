using CommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Interfaces.Repositories
{
    public interface IStockBatchRepository
    {
        Task AddAsync(StockBatch stockBatch, CancellationToken cancellationToken);
    }
}
