using CommerceSystem.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Domain.Entities
{
    public class StockMovement
    {
        public Guid Id { get; set; }

        public Guid BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        public Guid ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; } = null!;

        public int QuantityChange { get; set; }

        public StockMovementType MovementType { get; set; }

        public string? Note { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
