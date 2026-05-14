using CommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Interfaces.Repositories
{
    public interface IColorRepository
    {
        Task<List<Color>> GetAllAsync(CancellationToken cancellation);
        Task<Color?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
