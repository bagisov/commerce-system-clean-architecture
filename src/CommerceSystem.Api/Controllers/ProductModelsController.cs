using CommerceSystem.Application.Features.ProductModels.Commands.CreateProductModel;
using CommerceSystem.Application.Features.ProductModels.Queries.GetProductModelById;
using CommerceSystem.Application.Features.ProductModels.Queries.GetProductModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommerceSystem.Api.Controllers
{
    [Route("api/product-models")]
    [ApiController]
    public class ProductModelsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductModelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateProductModelCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductModelsQuery(), cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductModelByIdQuery { Id = id}, cancellationToken);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }


    }
}
