using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Domain.Entities
{
    public class Size
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public int? SortOrder { get; set; }
    }
}
