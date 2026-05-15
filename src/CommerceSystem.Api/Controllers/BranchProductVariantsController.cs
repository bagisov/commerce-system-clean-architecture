using CommerceSystem.Application.Features.BranchProductVariants.Commands.CreateBranchProductVariants;
using CommerceSystem.Application.Features.BranchProductVariants.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommerceSystem.Api.Controllers
{
    [Route("api/branch-product-variants")]
    [ApiController]
    public class BranchProductVariantsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BranchProductVariantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateBranchProductVariantsCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] SearchBranchProductVariantsQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }
    }
}
