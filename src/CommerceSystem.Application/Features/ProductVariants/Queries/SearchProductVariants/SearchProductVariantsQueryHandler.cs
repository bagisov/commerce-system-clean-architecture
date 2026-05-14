using CommerceSystem.Application.Features.ProductVariants.Dtos;
using CommerceSystem.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductVariants.Queries.SearchProductVariants
{
    public class SearchProductVariantsQueryHandler : IRequestHandler<SearchProductVariantsQuery, List<ProductVariantDto>>
    {
        private readonly IProductVariantRepository _productVariantRepository;

        public SearchProductVariantsQueryHandler(
            IProductVariantRepository productVariantRepository)
        {
            _productVariantRepository = productVariantRepository;
        }

        public async Task<List<ProductVariantDto>> Handle(
            SearchProductVariantsQuery request,
            CancellationToken cancellationToken)
        {
            var variants = await _productVariantRepository.SearchAsync(
                request.BrandId,
                request.CategoryId,
                request.ProductModelId,
                request.ColorIds,
                request.SizeIds,
                request.Status,
                request.SearchText,
                cancellationToken);

            return variants.Select(x => new ProductVariantDto
            {
                Id = x.Id,

                ProductModelId = x.ProductModelId,
                ProductModelName = x.ProductModel.Name,

                BrandId = x.ProductModel.BrandId,
                BrandName = x.ProductModel.Brand.Name,

                CategoryId = x.ProductModel.CategoryId,
                CategoryName = x.ProductModel.Category.Name,

                ColorId = x.ColorId,
                ColorName = x.Color?.Name,

                SizeId = x.SizeId,
                SizeName = x.Size?.Name,

                PurchasePrice = x.PurchasePrice,
                BaseSellingPrice = x.BaseSellingPrice,

                Status = x.Status
            }).ToList();
        }
    }
}
