using CommerceSystem.Application.Features.Branches.Dtos;
using CommerceSystem.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Branches.Queries.GetBranches
{
    public class GetBranchesQuery : IRequest<List<BranchDto>>
    {
        public Guid? BrandId { get; set; }

        public EntityStatus? Status { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }
    }
}
