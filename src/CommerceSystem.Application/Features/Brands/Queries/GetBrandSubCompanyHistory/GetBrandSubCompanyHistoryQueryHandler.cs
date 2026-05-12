using CommerceSystem.Application.Features.Brands.Dtos;
using CommerceSystem.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Brands.Queries.GetBrandSubCompanyHistory
{
    public class GetBrandSubCompanyHistoryQueryHandler : IRequestHandler<GetBrandSubCompanyHistoryQuery, List<BrandSubCompanyHistoryDto>>
    {
        private readonly IBrandSubCompanyHistoryRepository _repository;

        public GetBrandSubCompanyHistoryQueryHandler(IBrandSubCompanyHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BrandSubCompanyHistoryDto>> Handle(GetBrandSubCompanyHistoryQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByIdAsync(request.BrandId, cancellationToken);
            return entities.Select(x=> new BrandSubCompanyHistoryDto
            {
                BrandName = x.Brand.Name,
                SubCompanyName = x.SubCompany.Name,
                EnteredAtUtc = x.EnteredAtUtc,
                LeftAtUtc = x.LeftAtUtc
            }).ToList();
        }
    }
}
