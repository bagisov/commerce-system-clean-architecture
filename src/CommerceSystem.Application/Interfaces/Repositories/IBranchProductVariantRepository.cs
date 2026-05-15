using CommerceSystem.Common;
using CommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Interfaces.Repositories
{
    public interface IBranchProductVariantRepository
    {
        Task<bool> ExistsAsync(Guid branchId, Guid productVariantId, CancellationToken cancellationToken);

        Task AddAsync(BranchProductVariant branchProductVariant, CancellationToken cancellationToken);

        Task<List<BranchProductVariant>> SearchAsync(Guid? branchId, Guid? productVariantId, EntityStatus? status, CancellationToken cancellationToken);
    }
}
