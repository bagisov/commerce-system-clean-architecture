using CommerceSystem.Application.Features.Brands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<BrandDto>
    {
        public string Name { get; set; } = null!;
        public Guid SubCompanyId { get; set; }
    }
}
