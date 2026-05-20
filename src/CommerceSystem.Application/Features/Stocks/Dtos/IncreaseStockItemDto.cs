using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Stocks.Dtos
{
    public class IncreaseStockItemDto
    {
        public Guid ProductVariantId { get; set; }
        public int Quantity { get; set; }
    }
}
