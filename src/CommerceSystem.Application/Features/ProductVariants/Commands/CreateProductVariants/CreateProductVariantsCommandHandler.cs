using CommerceSystem.Application.Features.ProductVariants.Dtos;
using CommerceSystem.Application.Interfaces;
using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductVariants.Commands.CreateProductVariants
{
    public class CreateProductVariantsCommandHandler : IRequestHandler<CreateProductVariantsCommand, List<ProductVariantDto>>
    {
        private readonly IProductVariantRepository _productVariantRepository;
        private readonly IProductModelRepository _productModelRepository;
        private readonly IColorRepository _colorRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductVariantsCommandHandler(
            IProductVariantRepository productVariantRepository,
            IProductModelRepository productModelRepository,
            IColorRepository colorRepository,
            ISizeRepository sizeRepository,
            IUnitOfWork unitOfWork)
        {
            _productVariantRepository = productVariantRepository;
            _productModelRepository = productModelRepository;
            _colorRepository = colorRepository;
            _sizeRepository = sizeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ProductVariantDto>> Handle(CreateProductVariantsCommand request, CancellationToken cancellationToken)
        {
            var productModel = await _productModelRepository.GetByIdAsync(
                request.ProductModelId,
                cancellationToken);

            if (productModel is null)
                throw new Exception("Product model not found.");

            Color? color = null;

            if (request.ColorId.HasValue)
            {
                color = await _colorRepository.GetByIdAsync(request.ColorId.Value, cancellationToken);

                if (color is null)
                    throw new Exception("Color not found.");
            }

            var result = new List<ProductVariantDto>();

            var sizeIds = request.SizeIds is { Count: > 0 }
                ? request.SizeIds.Distinct().Cast<Guid?>().ToList()
                : new List<Guid?> { null };
            foreach (var sizeId in sizeIds)
            {
                Size? size = null;

                if (sizeId.HasValue)
                {
                    size = await _sizeRepository.GetByIdAsync(
                        sizeId.Value,
                        cancellationToken);

                    if (size is null)
                        continue;
                }


                var exists = await _productVariantRepository.ExistsAsync(
                    request.ProductModelId,
                    request.ColorId,
                    sizeId,
                    cancellationToken);

                if (exists)
                    continue;

                var productVariant = new ProductVariant
                {
                    Id = Guid.NewGuid(),
                    ProductModelId = request.ProductModelId,
                    ColorId = request.ColorId,
                    SizeId = sizeId,
                    PurchasePrice = request.PurchasePrice,
                    BaseSellingPrice = request.BaseSellingPrice,
                    Status = request.Status
                };

                await _productVariantRepository.AddAsync(
                    productVariant,
                    cancellationToken);

                result.Add(new ProductVariantDto
                {
                    Id = productVariant.Id,

                    ProductModelId = productModel.Id,
                    ProductModelName = productModel.Name,

                    BrandId = productModel.BrandId,
                    BrandName = productModel.Brand.Name,

                    CategoryId = productModel.CategoryId,
                    CategoryName = productModel.Category.Name,

                    ColorId = color?.Id,
                    ColorName = color?.Name,

                    SizeId = size?.Id,
                    SizeName = size?.Name,

                    PurchasePrice = productVariant.PurchasePrice,
                    BaseSellingPrice = productVariant.BaseSellingPrice,

                    Status = productVariant.Status
                });
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
