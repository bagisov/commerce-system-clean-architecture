using CommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Interfaces.Repositories
{
    public interface IProductVariantRepository
    {
        Task<ProductVariant?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(Guid productModelId, Guid colorId, Guid sizeId, CancellationToken cancellationToken);
        Task AddAsync(ProductVariant productVariant, CancellationToken cancellationToken);
    }
}
