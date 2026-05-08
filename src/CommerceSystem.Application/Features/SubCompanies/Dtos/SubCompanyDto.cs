using CommerceSystem.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.SubCompanies.Dtos
{
    public class SubCompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public EntityStatus Status { get; set; }
    }
}
