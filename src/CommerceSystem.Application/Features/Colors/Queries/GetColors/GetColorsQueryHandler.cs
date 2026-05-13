using CommerceSystem.Application.Features.Colors.Dtos;
using CommerceSystem.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Colors.Queries.GetColors
{
    public class GetColorsQueryHandler : IRequestHandler<GetColorsQuery, List<ColorDto>>
    {
        private readonly IColorRepository _colorRepository;

        public GetColorsQueryHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<List<ColorDto>> Handle(GetColorsQuery request, CancellationToken cancellationToken)
        {
            var colors = await _colorRepository.GetAllAsync(cancellationToken);

            return colors.Select(x => new ColorDto
            {
                Id = x.Id,
                Name = x.Name,
                HexCode = x.HexCode
            }).ToList();
        }
    }
}
