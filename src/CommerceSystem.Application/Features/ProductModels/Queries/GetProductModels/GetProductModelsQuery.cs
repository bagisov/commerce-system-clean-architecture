using CommerceSystem.Application.Features.ProductCategories.Dtos;
using CommerceSystem.Application.Features.ProductModels.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductModels.Queries.GetProductModels
{
    public class GetProductModelsQuery : IRequest<List<ProductModelDto>>
    {
    }
}
