using CommerceSystem.Application.Features.Sizes.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Sizes.Queries.GetSizes
{
    public class GetSizesQuery : IRequest<List<SizeDto>>
    {
    }
}
