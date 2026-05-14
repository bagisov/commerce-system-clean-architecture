using CommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Interfaces.Repositories
{
    public interface IProductModelRepository
    {
        Task<List<ProductModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<ProductModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task AddAsync(ProductModel productModel, CancellationToken cancellationToken);
        Task<bool> ExistsByNameAsync(Guid brandId, Guid categoryId, string name, CancellationToken cancellationToken);
    }
}
