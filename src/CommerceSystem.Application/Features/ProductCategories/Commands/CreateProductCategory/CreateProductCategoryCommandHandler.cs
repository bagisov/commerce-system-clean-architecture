using CommerceSystem.Application.Features.ProductCategories.Dtos;
using CommerceSystem.Application.Interfaces;
using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductCategories.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, ProductCategoryDto>
    {
        private readonly IProductCategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCategoryCommandHandler(IProductCategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;   
        }

        public async Task<ProductCategoryDto> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.ExistsByNameAsync(request.Name);
            
            if (exists) { throw new Exception("Category already exists"); }
            
            var entity = new ProductCategory
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Status = Common.EntityStatus.Active
            };
            
            await _repository.AddAsync(entity);
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            return new ProductCategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Status = entity.Status
            };

        }
    }
}
