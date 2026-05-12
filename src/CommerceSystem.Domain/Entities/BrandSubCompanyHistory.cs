using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Domain.Entities
{
    public class BrandSubCompanyHistory
    {
        public Guid Id { get; set; }

        public Guid BrandId { get; set; }

        public Brand Brand { get; set; } = null!;

        public Guid SubCompanyId { get; set; }

        public SubCompany SubCompany { get; set; } = null!;

        public DateTime EnteredAtUtc { get; set; }

        public DateTime LeftAtUtc { get; set; }
    }
}
