using CommerceSystem.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public decimal PurchasePrice { get; set; }
        public decimal BaseSellingPrice { get; set; }
        public string Color { get; set; } = null!;
        public string Size { get; set; } = null!;
        public EntityStatus Status { get; set; } = EntityStatus.Active;
    }
}