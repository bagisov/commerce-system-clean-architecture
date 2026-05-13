using CommerceSystem.Application.Features.Branches.Dtos;
using CommerceSystem.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Branches.Queries.GetBranches
{
    public class GetBranchesQueryHandler
        : IRequestHandler<GetBranchesQuery, List<BranchDto>>
    {
        private readonly IBranchRepository _repository;

        public GetBranchesQueryHandler(IBranchRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BranchDto>> Handle(
            GetBranchesQuery request,
            CancellationToken cancellationToken)
        {
            var branches = await _repository.GetFilteredAsync(
                request.BrandId,
                request.Status,
                request.Name,
                request.Address,
                cancellationToken);

            return branches.Select(x => new BranchDto
            {
                Id = x.Id,
                BrandId = x.BrandId,
                BrandName = x.Brand.Name,
                Name = x.Name,
                Address = x.Address,
                Status = x.Status,
                CreatedAtUtc = x.CreatedAtUtc
            }).ToList();
        }
    }
}
