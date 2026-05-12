using CommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Interfaces.Repositories
{
    public interface IBrandSubCompanyHistoryRepository
    {
        Task AddAsync(BrandSubCompanyHistory history,CancellationToken cancellationToken);
        Task<List<BrandSubCompanyHistory>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
