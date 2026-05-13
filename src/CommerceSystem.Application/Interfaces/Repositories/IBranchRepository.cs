using CommerceSystem.Common;
using CommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Interfaces.Repositories
{
    public interface IBranchRepository
    {
        Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);

        Task AddAsync(Branch branch, CancellationToken cancellationToken);

        Task<List<Branch>> GetFilteredAsync(Guid? brandId, EntityStatus? status, string? name, string? address, CancellationToken cancellationToken);

        Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        void Delete(Branch branch);
    }
}
