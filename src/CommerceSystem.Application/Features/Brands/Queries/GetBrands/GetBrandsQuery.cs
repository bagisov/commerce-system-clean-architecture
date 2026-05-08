using CommerceSystem.Application.Features.Brands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Brands.Queries.GetBrands
{
    public class GetBrandsQuery : IRequest<List<BrandDto>>
    {

    }
}
