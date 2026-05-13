using CommerceSystem.Application.Features.Branches.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Branches.Commands.CreateBranch
{
    public class CreateBranchCommand : IRequest<BranchDto>
    {
        public Guid BrandId { get; set; }

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;
    }
}
