using CommerceSystem.Application.Features.Brands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Brands.Queries.GetBrandSubCompanyHistory
{
    public class GetBrandSubCompanyHistoryQuery : IRequest<List<BrandSubCompanyHistoryDto>>
    {
        public Guid BrandId { get; set; }
    }
}
