using CommerceSystem.Application.Features.SubCompanies.Dtos;
using CommerceSystem.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.SubCompanies.Queries.GetSubCompanies
{
    public class GetSubCompaniesQueryHandler : IRequestHandler<GetSubCompaniesQuery, List<SubCompanyDto>>
    {
        private readonly ISubCompanyRepository _repository;
        
        public GetSubCompaniesQueryHandler(ISubCompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SubCompanyDto>> Handle(GetSubCompaniesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync(cancellationToken);
            return entities.Select(x => new SubCompanyDto
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status
            }).ToList();
            
        }
    }
}
