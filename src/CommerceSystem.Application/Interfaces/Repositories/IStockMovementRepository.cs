using CommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Interfaces.Repositories
{
    public interface IStockMovementRepository
    {
        Task AddAsync(StockMovement stockMovement, CancellationToken cancellationToken);
    }
}
