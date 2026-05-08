using CommerceSystem.Application.Features.ProductCategories.Dtos;
using CommerceSystem.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductCategories.Commands.UpdateProductCategory
{
    public class UpdateProductCategoryCommand : IRequest<ProductCategoryDto>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public EntityStatus? Status { get; set; }
    }
}
