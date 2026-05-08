using CommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Interfaces.Repositories
{
    public interface IBrandRepository
    {
        Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
        Task AddAsync(Brand brand, CancellationToken cancellationToken);
        Task<Brand?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Brand>>  GetAllAsync(CancellationToken cancellationToken);
    }
}
