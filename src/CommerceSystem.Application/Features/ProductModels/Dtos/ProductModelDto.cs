using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductModels.Dtos
{
    public class ProductModelDto
    {
        public Guid Id { get; set; }
        public Guid BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
