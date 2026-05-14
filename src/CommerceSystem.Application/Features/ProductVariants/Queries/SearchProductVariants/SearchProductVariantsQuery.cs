using CommerceSystem.Application.Features.ProductVariants.Dtos;
using CommerceSystem.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductVariants.Queries.SearchProductVariants
{
    public class SearchProductVariantsQuery : IRequest<List<ProductVariantDto>>
    {
        public Guid? BrandId { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? ProductModelId { get; set; }

        public List<Guid>? ColorIds { get; set; }
        public List<Guid>? SizeIds { get; set; }

        public EntityStatus? Status { get; set; }

        public string? SearchText { get; set; }
    }
}
