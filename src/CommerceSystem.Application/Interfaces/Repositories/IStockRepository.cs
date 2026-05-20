using CommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Interfaces.Repositories
{
    public interface IStockRepository
    {
        Task<List<Stock>> SearchAsync(
            Guid? branchId,
            Guid? brandId,
            Guid? categoryId,
            Guid? productModelId,
            Guid? productVariantId,
            string? searchText,
            CancellationToken cancellationToken);

        Task<Stock?> GetByBranchAndProductVariantAsync(Guid branchId, Guid productVariantId, CancellationToken cancellationToken);

        Task AddAsync(Stock stock, CancellationToken cancellationToken);

        void Update(Stock stock);
    }
}
