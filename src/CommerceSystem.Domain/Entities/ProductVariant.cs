using CommerceSystem.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Domain.Entities
{
    public class ProductVariant
    {
        public Guid Id { get; set; }

        public Guid ProductModelId { get; set; }
        public ProductModel ProductModel { get; set; } = null!;

        public Guid? ColorId { get; set; }
        public Color? Color { get; set; }

        public Guid? SizeId { get; set; }
        public Size? Size { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal BaseSellingPrice { get; set; }

        public EntityStatus Status { get; set; } = EntityStatus.Active;
    }
}
