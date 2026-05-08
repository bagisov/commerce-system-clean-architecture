using CommerceSystem.Application.Features.ProductCategories.Dtos;
using CommerceSystem.Application.Interfaces;
using CommerceSystem.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductCategories.Commands.UpdateProductCategory
{
    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, ProductCategoryDto?>
    {
        private readonly IProductCategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCategoryCommandHandler(IProductCategoryRepository repository, IUnitOfWork unitOfWork)     
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public async Task<ProductCategoryDto?> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                entity.Name = request.Name;
            }

            if (request.Status.HasValue)
            {
                entity.Status = request.Status.Value;
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ProductCategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Status = entity.Status,
            };

        }
    }
}
