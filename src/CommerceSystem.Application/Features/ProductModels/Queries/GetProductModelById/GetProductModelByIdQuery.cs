using CommerceSystem.Application.Features.ProductModels.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductModels.Queries.GetProductModelById
{
    public class GetProductModelByIdQuery : IRequest<ProductModelDto?>
    {
        public Guid Id { get; set; }
    }
}
