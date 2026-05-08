using CommerceSystem.Application.Features.ProductCategories.Dtos;
using CommerceSystem.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductCategories.Queries.GetProductCategories
{
    public class GetProductCategoriesQueryHandler : IRequestHandler<GetProductCategoriesQuery, List<ProductCategoryDto>>
    {
        private readonly IProductCategoryRepository _repository;
        public GetProductCategoriesQueryHandler(IProductCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductCategoryDto>> Handle(GetProductCategoriesQuery request,  CancellationToken cancellationToken)
        {
            var productCategories = await _repository.GetAllAsync();
            return productCategories.Select(x => new ProductCategoryDto 
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status,
            }).ToList();
        }
    }
}
