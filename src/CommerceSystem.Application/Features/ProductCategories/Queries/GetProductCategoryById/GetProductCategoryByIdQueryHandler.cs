using CommerceSystem.Application.Features.ProductCategories.Dtos;
using CommerceSystem.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductCategories.Queries.GetProductCategoryById
{
    internal class GetProductCategoryByIdQueryHandler : IRequestHandler<GetProductCategoryByIdQuery, ProductCategoryDto?>
    {
        private readonly IProductCategoryRepository _repository;

        public GetProductCategoryByIdQueryHandler(IProductCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductCategoryDto?> Handle(GetProductCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return null;
            }

            return new ProductCategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Status = entity.Status,
            };
        }
    }
}
