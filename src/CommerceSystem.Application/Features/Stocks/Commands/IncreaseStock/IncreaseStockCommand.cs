using CommerceSystem.Application.Features.Stocks.Dtos;
using CommerceSystem.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Stocks.Commands.IncreaseStock
{
    public class IncreaseStockCommand : IRequest
    {
        public Guid BranchId { get; set; }
        public List<IncreaseStockItemDto> Items { get; set; } = new();
        public string? Note { get; set; }
    }
}
