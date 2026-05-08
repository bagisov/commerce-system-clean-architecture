using CommerceSystem.Application.Features.ProductCategories.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductCategories.Queries.GetProductCategories
{
    public class GetProductCategoriesQuery : IRequest<List<ProductCategoryDto>>
    {
    }
}
