using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Repositories
{
    public class SubCompanyRepository : ISubCompanyRepository
    {
        private readonly CommerceDbContext _context;

        public SubCompanyRepository(CommerceDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SubCompany subCompany, CancellationToken cancellationToken)
        {
            await _context.SubCompanies.AddAsync(subCompany, cancellationToken);
        }

        public void Delete(SubCompany subCompany)
        {
            _context.SubCompanies.Remove(subCompany);
        }

        public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _context.SubCompanies.AnyAsync(x=> x.Name == name, cancellationToken);
        }

        public async Task<List<SubCompany>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.SubCompanies.ToListAsync(cancellationToken);
        }

        public async Task<SubCompany?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.SubCompanies.FirstOrDefaultAsync(x=> x.Id == id, cancellationToken);
        }
    }
}
