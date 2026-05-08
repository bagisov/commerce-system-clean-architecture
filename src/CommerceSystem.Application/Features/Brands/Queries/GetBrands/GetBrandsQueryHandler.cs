using CommerceSystem.Application.Features.Brands.Dtos;
using CommerceSystem.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Brands.Queries.GetBrands
{
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery,List<BrandDto>>
    {
        private readonly IBrandRepository _brandRepository;
        public GetBrandsQueryHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<List<BrandDto>> Handle(GetBrandsQuery requet, CancellationToken cancellationToken)
        {
            var entities = await _brandRepository.GetAllAsync(cancellationToken);

            return entities.Select(x => new BrandDto
            {
                Id = x.Id,
                Name = x.Name,
                SubCompanyId = x.SubCompanyId,
                JoinedSubCompanyAtUtc = x.JoinedSubCompanyAtUtc,
                Status = x.Status
            }).ToList();
        }
    }
}
