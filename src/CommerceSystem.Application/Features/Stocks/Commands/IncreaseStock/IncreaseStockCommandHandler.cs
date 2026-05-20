using CommerceSystem.Application.Interfaces.Services;
using CommerceSystem.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Stocks.Commands.IncreaseStock
{
    public class IncreaseStockCommandHandler
           : IRequestHandler<IncreaseStockCommand>
    {
        private readonly IStockService _stockService;

        public IncreaseStockCommandHandler(IStockService stockService)
        {
            _stockService = stockService;
        }

        public async Task Handle(
            IncreaseStockCommand request,
            CancellationToken cancellationToken)
        {
            await _stockService.IncreaseAsync(
                request.BranchId,
                request.Items,
                StockMovementType.Purchase,
                request.Note,
                cancellationToken);
        }
    }
}
