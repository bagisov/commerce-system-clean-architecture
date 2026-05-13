using CommerceSystem.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Branches.Dtos
{
    public class BranchDto
    {
        public Guid Id { get; set; }

        public Guid BrandId { get; set; }

        public string BrandName { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public EntityStatus Status { get; set; }

        public DateTime CreatedAtUtc { get; set; }
    }
}
