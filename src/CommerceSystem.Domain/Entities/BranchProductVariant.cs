using CommerceSystem.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Domain.Entities
{
    public class BranchProductVariant
    {
        public Guid Id { get; set; }
        public Guid BranchId { get; set; }
        public Branch Branch { get; set; } = null!;
        public Guid ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; } = null!;
        public EntityStatus Status { get; set; } = EntityStatus.Active;
    }
}
