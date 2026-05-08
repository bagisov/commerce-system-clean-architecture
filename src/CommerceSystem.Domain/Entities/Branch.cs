using CommerceSystem.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Domain.Entities
{
    public class Branch
    {
        public Guid Id { get; set; }
        public Guid BrandId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public EntityStatus Status { get; set; } = EntityStatus.Active;
    }
}
