using CommerceSystem.Application.Features.Brands.Dtos;
using CommerceSystem.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Brands.Queries.GetBrendById
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, BrandDto?>
    {
        private readonly IBrandRepository _repository;

        public GetBrandByIdQueryHandler(IBrandRepository repository) 
        {
            _repository = repository;
        }

        public async Task<BrandDto?> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var entity =  await _repository.GetByIdAsync(request.Id, cancellationToken);
            
            if (entity == null)
            {
                return null;
            }

            return new BrandDto
            {
                Id = entity.Id,
                Name = entity.Name,
                SubCompanyId = entity.SubCompanyId,
                JoinedSubCompanyAtUtc = entity.JoinedSubCompanyAtUtc,
                Status = entity.Status
            };
        }
    }
}
