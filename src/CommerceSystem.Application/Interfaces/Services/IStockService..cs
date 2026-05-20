using CommerceSystem.Application.Features.Stocks.Dtos;
using CommerceSystem.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Interfaces.Services
{
    public interface IStockService
    {
        Task IncreaseAsync(
            Guid branchId,
            List<IncreaseStockItemDto> items,
            StockMovementType movementType,
            string? note,
            CancellationToken cancellationToken);

        Task DecreaseAsync(
            Guid branchId,
            Guid productVariantId,
            int quantity,
            StockMovementType movementType,
            CancellationToken cancellationToken);
    }
}
