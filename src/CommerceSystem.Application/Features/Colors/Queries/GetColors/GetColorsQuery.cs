using CommerceSystem.Application.Features.Colors.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Colors.Queries.GetColors
{
    public class GetColorsQuery : IRequest<List<ColorDto>>
    {
    }
}
