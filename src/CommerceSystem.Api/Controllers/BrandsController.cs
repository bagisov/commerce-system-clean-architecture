using CommerceSystem.Application.Features.Brands.Commands.CreateBrand;
using CommerceSystem.Application.Features.Brands.Dtos;
using CommerceSystem.Application.Features.Brands.Queries.GetBrands;
using CommerceSystem.Application.Features.Brands.Queries.GetBrendById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace CommerceSystem.Api.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BrandDto>> Create(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetBrandByIdQuery { Id = id }, cancellationToken);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        [HttpGet]
        public async Task<ActionResult<List<BrandDto>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetBrandsQuery(),cancellationToken);
            return Ok(result);
        }

    }
}
