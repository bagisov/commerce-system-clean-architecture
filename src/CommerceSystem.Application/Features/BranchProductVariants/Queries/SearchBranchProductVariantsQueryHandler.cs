using CommerceSystem.Application.Features.BranchProductVariants.Dtos;
using CommerceSystem.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.BranchProductVariants.Queries
{
    public class SearchBranchProductVariantsQueryHandler : IRequestHandler<SearchBranchProductVariantsQuery, List<BranchProductVariantDto>>
    {
        private readonly IBranchProductVariantRepository _repository;

        public SearchBranchProductVariantsQueryHandler(IBranchProductVariantRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BranchProductVariantDto>> Handle(SearchBranchProductVariantsQuery request, CancellationToken cancellationToken)
        {
            var items = await _repository.SearchAsync(
                request.BranchId,
                request.ProductVariantId,
                request.Status,
                cancellationToken);

            return items.Select(x => new BranchProductVariantDto
            {
                Id = x.Id,

                BranchId = x.BranchId,
                BranchName = x.Branch.Name,

                ProductVariantId = x.ProductVariantId,

                ProductModelId = x.ProductVariant.ProductModelId,
                ProductModelName = x.ProductVariant.ProductModel.Name,

                BrandId = x.ProductVariant.ProductModel.BrandId,
                BrandName = x.ProductVariant.ProductModel.Brand.Name,

                CategoryId = x.ProductVariant.ProductModel.CategoryId,
                CategoryName = x.ProductVariant.ProductModel.Category.Name,

                ColorId = x.ProductVariant.ColorId,
                ColorName = x.ProductVariant.Color?.Name,

                SizeId = x.ProductVariant.SizeId,
                SizeName = x.ProductVariant.Size?.Name,

                PurchasePrice = x.ProductVariant.PurchasePrice,
                BaseSellingPrice = x.ProductVariant.BaseSellingPrice,

                ProductVariantStatus = x.ProductVariant.Status,
                Status = x.Status
            }).ToList();
        }
    }
}
