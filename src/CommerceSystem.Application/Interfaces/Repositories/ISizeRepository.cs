using CommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Interfaces.Repositories
{
    public interface ISizeRepository
    {
        Task<List<Size>> GetAllAsync(CancellationToken cancellationToken);
        Task<Size?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
