using CommerceSystem.Application.Features.Sizes.Dtos;
using CommerceSystem.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Sizes.Queries.GetSizes
{
    public class GetSizesQueryHandler : IRequestHandler<GetSizesQuery, List<SizeDto>>
    {
        private readonly ISizeRepository _sizeRepository;

        public GetSizesQueryHandler(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public async Task<List<SizeDto>> Handle(GetSizesQuery request, CancellationToken cancellationToken)
        {
            var sizes = await _sizeRepository.GetAllAsync(cancellationToken);

            return sizes.Select(x => new SizeDto
            {
                Id = x.Id,
                Name = x.Name,
                SortOrder = x.SortOrder
            }).ToList();
        }
    }
}
