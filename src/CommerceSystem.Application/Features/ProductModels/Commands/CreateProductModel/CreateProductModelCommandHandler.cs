using CommerceSystem.Application.Features.ProductModels.Dtos;
using CommerceSystem.Application.Interfaces;
using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductModels.Commands.CreateProductModel
{
    public class CreateProductModelCommandHandler : IRequestHandler<CreateProductModelCommand, ProductModelDto>
    {
        private readonly IProductModelRepository _productModelRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IProductCategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductModelCommandHandler(
            IProductModelRepository productModelRepository,
            IBrandRepository brandRepository,
            IProductCategoryRepository categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _productModelRepository = productModelRepository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductModelDto> Handle(
    CreateProductModelCommand request,
    CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(request.BrandId, cancellationToken);

            if (brand is null)
            {
                throw new Exception("Brand not found.");
            }

            var category = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

            if (category is null)
            {
                throw new Exception("Product category not found.");
            }

            var exists = await _productModelRepository.ExistsByNameAsync(
                request.BrandId,
                request.CategoryId,
                request.Name,
                cancellationToken);

            if (exists)
            {
                throw new Exception("Product model already exists.");
            }

            var productModel = new ProductModel
            {
                Id = Guid.NewGuid(),
                BrandId = request.BrandId,
                CategoryId = request.CategoryId,
                Name = request.Name.Trim()
            };

            await _productModelRepository.AddAsync(productModel, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ProductModelDto
            {
                Id = productModel.Id,
                BrandId = productModel.BrandId,
                BrandName = brand.Name,
                CategoryId = productModel.CategoryId,
                CategoryName = category.Name,
                Name = productModel.Name
            };
        }
    }
}
