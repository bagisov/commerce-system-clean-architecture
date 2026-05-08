using CommerceSystem.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Brands.Dtos
{
    public class BrandDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public Guid SubCompanyId { get; set; }

        public DateTime JoinedSubCompanyAtUtc { get; set; }

        public EntityStatus Status { get; set; }
    }
}
