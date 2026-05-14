using CommerceSystem.Common;
using CommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Interfaces.Repositories
{
    public interface IProductVariantRepository
    {
        Task<ProductVariant?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(Guid productModelId, Guid? colorId, Guid? sizeId, CancellationToken cancellationToken);
        Task AddAsync(ProductVariant productVariant, CancellationToken cancellationToken);
        Task<List<ProductVariant>> SearchAsync(
            Guid? brandId,
            Guid? categoryId,
            Guid? productModelId,
            List<Guid>? colorIds,
            List<Guid>? sizeIds,
            EntityStatus? status,
            string? searchText,
            CancellationToken cancellationToken);
    }
}
