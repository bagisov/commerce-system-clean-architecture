using CommerceSystem.Application.Features.ProductCategories.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductCategories.Queries.GetProductCategoryById
{
    public class GetProductCategoryByIdQuery : IRequest<ProductCategoryDto>
    {
        public Guid Id { get; set; }
    }
}
