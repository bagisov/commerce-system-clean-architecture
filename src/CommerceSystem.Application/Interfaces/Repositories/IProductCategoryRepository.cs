using CommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Interfaces.Repositories
{
    public interface IProductCategoryRepository
    {
        Task<bool> ExistsByNameAsync(string name);
        Task AddAsync(ProductCategory category);
        Task<List<ProductCategory>> GetAllAsync();
        Task<ProductCategory?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task DeleteAsync(ProductCategory category);
    }
}
