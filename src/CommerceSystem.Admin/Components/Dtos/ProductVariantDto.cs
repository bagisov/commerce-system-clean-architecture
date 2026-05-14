namespace CommerceSystem.Admin.Components.Dtos
{
    public class ProductVariantDto
    {
        public Guid Id { get; set; }

        public Guid ProductModelId { get; set; }
        public string ProductModelName { get; set; } = string.Empty;

        public Guid BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public Guid? ColorId { get; set; }
        public string? ColorName { get; set; }

        public Guid? SizeId { get; set; }
        public string? SizeName { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal BaseSellingPrice { get; set; }

        public EntityStatus Status { get; set; }
    }
}
