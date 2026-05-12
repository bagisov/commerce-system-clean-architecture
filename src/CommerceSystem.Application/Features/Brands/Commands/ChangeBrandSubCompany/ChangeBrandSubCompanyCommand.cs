using CommerceSystem.Application.Features.Brands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Brands.Commands.ChangeBrandSubCompany
{
    public class ChangeBrandSubCompanyCommand : IRequest<BrandDto>
    {
        public Guid BrandId { get; set; }
        public Guid NewSubCompanyId { get; set; }
    }
}
