using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Brands.Dtos
{
    public class BrandSubCompanyHistoryDto
    {
        public string BrandName { get; set; } = null!;

        public string SubCompanyName { get; set; } = null!;

        public DateTime EnteredAtUtc { get; set; }

        public DateTime LeftAtUtc { get; set; }
    }
}
