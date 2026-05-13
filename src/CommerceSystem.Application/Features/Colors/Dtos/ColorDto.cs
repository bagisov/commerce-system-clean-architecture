using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Colors.Dtos
{
    public class ColorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? HexCode { get; set; }
    }
}
