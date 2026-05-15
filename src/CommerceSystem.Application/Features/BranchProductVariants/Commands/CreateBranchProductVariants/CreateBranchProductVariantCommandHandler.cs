using CommerceSystem.Application.Features.BranchProductVariants.Dtos;
using CommerceSystem.Application.Interfaces;
using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.BranchProductVariants.Commands.CreateBranchProductVariants
{
    public class CreateBranchProductVariantsCommandHandler : IRequestHandler<CreateBranchProductVariantsCommand, List<BranchProductVariantDto>>
    {
        private readonly IBranchProductVariantRepository _branchProductVariantRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IProductVariantRepository _productVariantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBranchProductVariantsCommandHandler(
            IBranchProductVariantRepository branchProductVariantRepository,
            IBranchRepository branchRepository,
            IProductVariantRepository productVariantRepository,
            IUnitOfWork unitOfWork)
        {
            _branchProductVariantRepository = branchProductVariantRepository;
            _branchRepository = branchRepository;
            _productVariantRepository = productVariantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<BranchProductVariantDto>> Handle(CreateBranchProductVariantsCommand request, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.GetByIdAsync(request.BranchId, cancellationToken);

            if (branch is null)
                throw new Exception("Branch not found.");

            var result = new List<BranchProductVariantDto>();

            foreach (var productVariantId in request.ProductVariantIds.Distinct())
            {
                var productVariant = await _productVariantRepository.GetByIdAsync(productVariantId, cancellationToken);

                if (productVariant is null)
                    continue;

                var exists = await _branchProductVariantRepository.ExistsAsync(request.BranchId, productVariantId, cancellationToken);

                if (exists)
                    continue;

                var entity = new BranchProductVariant
                {
                    Id = Guid.NewGuid(),
                    BranchId = request.BranchId,
                    ProductVariantId = productVariantId,
                    Status = request.Status
                };

                await _branchProductVariantRepository.AddAsync(entity, cancellationToken);

                result.Add(new BranchProductVariantDto
                {
                    Id = entity.Id,

                    BranchId = branch.Id,
                    BranchName = branch.Name,

                    ProductVariantId = productVariant.Id,

                    ProductModelId = productVariant.ProductModelId,
                    ProductModelName = productVariant.ProductModel.Name,

                    BrandId = productVariant.ProductModel.BrandId,
                    BrandName = productVariant.ProductModel.Brand.Name,

                    CategoryId = productVariant.ProductModel.CategoryId,
                    CategoryName = productVariant.ProductModel.Category.Name,

                    ColorId = productVariant.ColorId,
                    ColorName = productVariant.Color?.Name,

                    SizeId = productVariant.SizeId,
                    SizeName = productVariant.Size?.Name,

                    PurchasePrice = productVariant.PurchasePrice,
                    BaseSellingPrice = productVariant.BaseSellingPrice,

                    ProductVariantStatus = productVariant.Status,
                    Status = entity.Status
                });
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
