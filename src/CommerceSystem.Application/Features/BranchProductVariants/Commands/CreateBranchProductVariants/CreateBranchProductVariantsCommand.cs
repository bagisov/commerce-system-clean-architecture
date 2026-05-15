using CommerceSystem.Application.Features.BranchProductVariants.Dtos;
using CommerceSystem.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.BranchProductVariants.Commands.CreateBranchProductVariants
{
    public class CreateBranchProductVariantsCommand : IRequest<List<BranchProductVariantDto>>
    {
        public Guid BranchId { get; set; }
        public List<Guid> ProductVariantIds { get; set; } = new();
        public EntityStatus Status { get; set; } = EntityStatus.Active;
    }
}
