using CommerceSystem.Application.Features.Brands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Brands.Queries.GetBrendById
{
    public class GetBrandByIdQuery : IRequest<BrandDto>
    {
        public Guid Id { get; set; }
    }
}
