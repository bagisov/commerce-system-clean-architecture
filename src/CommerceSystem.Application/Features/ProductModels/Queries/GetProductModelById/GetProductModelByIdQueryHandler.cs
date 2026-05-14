using CommerceSystem.Application.Features.ProductModels.Dtos;
using CommerceSystem.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductModels.Queries.GetProductModelById
{
    public class GetProductModelByIdQueryHandler : IRequestHandler<GetProductModelByIdQuery, ProductModelDto?>
    {
        private readonly IProductModelRepository _productModelRepository;

        public GetProductModelByIdQueryHandler(IProductModelRepository productModelRepository)
        {
            _productModelRepository = productModelRepository;
        }

        public async Task<ProductModelDto?> Handle(GetProductModelByIdQuery request, CancellationToken cancellationToken)
        {
            var productModel = await _productModelRepository.GetByIdAsync(request.Id, cancellationToken);

            if (productModel is null)
            {
                return null;
            }

            return new ProductModelDto
            {
                Id = productModel.Id,
                BrandId = productModel.BrandId,
                BrandName = productModel.Brand.Name,
                CategoryId = productModel.CategoryId,
                CategoryName = productModel.Category.Name,
                Name = productModel.Name
            };
        }
    }
}
