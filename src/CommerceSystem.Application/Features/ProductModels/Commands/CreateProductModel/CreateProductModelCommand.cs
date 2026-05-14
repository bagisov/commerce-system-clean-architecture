using CommerceSystem.Application.Features.ProductModels.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductModels.Commands.CreateProductModel
{
    public class CreateProductModelCommand : IRequest<ProductModelDto>
    {
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = null!;
    }
}
