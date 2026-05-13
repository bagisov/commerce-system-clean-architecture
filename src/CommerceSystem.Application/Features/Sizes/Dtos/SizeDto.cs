using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Sizes.Dtos
{
    public class SizeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int? SortOrder { get; set; }
    }
}
