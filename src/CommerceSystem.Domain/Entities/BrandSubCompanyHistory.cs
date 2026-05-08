using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Domain.Entities
{
    public class BrandSubCompanyHistory
    {
        public Guid Id { get; set; }

        public Guid BrandId { get; set; }

        public Guid SubCompanyId { get; set; }

        public DateTime EnteredAtUtc { get; set; }

        public DateTime LeftAtUtc { get; set; }
    }
}
