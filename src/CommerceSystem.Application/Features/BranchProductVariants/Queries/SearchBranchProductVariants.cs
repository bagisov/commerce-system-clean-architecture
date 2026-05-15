using CommerceSystem.Application.Features.BranchProductVariants.Dtos;
using CommerceSystem.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.BranchProductVariants.Queries
{
    public class SearchBranchProductVariantsQuery : IRequest<List<BranchProductVariantDto>>
    {
        public Guid? BranchId { get; set; }

        public Guid? ProductVariantId { get; set; }

        public EntityStatus? Status { get; set; }
    }
}
