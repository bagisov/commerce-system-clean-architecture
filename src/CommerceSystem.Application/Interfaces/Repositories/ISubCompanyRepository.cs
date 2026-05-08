using CommerceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Interfaces.Repositories
{
    public interface ISubCompanyRepository
    {
        Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
        Task AddAsync(SubCompany subCompany, CancellationToken cancellationToken);
        Task<List<SubCompany>> GetAllAsync(CancellationToken cancellationToken);
        Task<SubCompany?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        void Delete(SubCompany subCompany);
        Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
