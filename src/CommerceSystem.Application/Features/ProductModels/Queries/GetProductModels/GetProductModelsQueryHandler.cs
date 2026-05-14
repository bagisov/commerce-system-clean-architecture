using CommerceSystem.Application.Features.ProductModels.Dtos;
using CommerceSystem.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductModels.Queries.GetProductModels
{
    public class GetProductModelsQueryHandler : IRequestHandler<GetProductModelsQuery, List<ProductModelDto>>
    {
        private readonly IProductModelRepository _productModelRepository;

        public GetProductModelsQueryHandler(IProductModelRepository productModelRepository)
        {
            _productModelRepository = productModelRepository;
        }

        public async Task<List<ProductModelDto>> Handle(GetProductModelsQuery request, CancellationToken cancellationToken)
        {
            var productModels = await _productModelRepository.GetAllAsync(cancellationToken);

            return productModels
                .Select(x => new ProductModelDto
                {
                    Id = x.Id,
                    BrandId = x.BrandId,
                    BrandName = x.Brand.Name,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    Name = x.Name
                })
                .OrderBy(x => x.Name)
                .ToList();
        }
    }
}
