using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Domain.Entities
{
    public class ProductModel
    {
        public Guid Id { get; set; }

        public Guid BrandId { get; set; }
        public Brand Brand { get; set; } = null!;

        public Guid CategoryId { get; set; }
        public ProductCategory Category { get; set; } = null!;

        public string Name { get; set; } = null!;

        public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
    }
}
