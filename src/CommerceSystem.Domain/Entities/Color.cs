using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Domain.Entities
{
    public class Color
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? HexCode { get; set; }
    }
}
