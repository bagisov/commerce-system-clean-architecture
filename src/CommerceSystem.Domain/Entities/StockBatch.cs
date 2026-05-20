using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Domain.Entities
{
    public class StockBatch
    {
        public Guid Id { get; set; }

        public Guid BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        public Guid ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; } = null!;

        public int InitialQuantity { get; set; }

        public int RemainingQuantity { get; set; }

        public decimal UnitCost { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
