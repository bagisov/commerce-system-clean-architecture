using CommerceSystem.Application.Features.ProductVariants.Commands.CreateProductVariants;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommerceSystem.Api.Controllers
{
    [Route("api/product-variants")]
    [ApiController]
    public class ProductVariantsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductVariantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateProductVariantsCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                command,
                cancellationToken);

            return Ok(result);
        }
    }
}
