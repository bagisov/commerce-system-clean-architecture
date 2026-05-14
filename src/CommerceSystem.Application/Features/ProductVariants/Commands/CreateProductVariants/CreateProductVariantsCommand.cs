using CommerceSystem.Application.Features.ProductVariants.Dtos;
using CommerceSystem.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductVariants.Commands.CreateProductVariants
{
    public class CreateProductVariantsCommand : IRequest<List<ProductVariantDto>>
    {
        public Guid ProductModelId { get; set; }

        public Guid? ColorId { get; set; }

        public List<Guid>? SizeIds { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal BaseSellingPrice { get; set; }

        public EntityStatus Status { get; set; } = EntityStatus.Active;
    }
}
