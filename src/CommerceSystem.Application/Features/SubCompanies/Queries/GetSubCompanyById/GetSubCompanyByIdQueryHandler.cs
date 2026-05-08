using CommerceSystem.Application.Features.SubCompanies.Dtos;
using CommerceSystem.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.SubCompanies.Queries.GetSubCompanyById
{
    public class GetSubCompanyByIdQueryHandler : IRequestHandler<GetSubCompanyByIdQuery, SubCompanyDto?>
    {
        private readonly ISubCompanyRepository _repository;

        public GetSubCompanyByIdQueryHandler(ISubCompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<SubCompanyDto?> Handle(GetSubCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
            {
                return null;
            }
            return new SubCompanyDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Status = entity.Status,
            };
        }
    }
}
