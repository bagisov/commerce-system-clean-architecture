using CommerceSystem.Application.Features.Branches.Commands.CreateBranch;
using CommerceSystem.Application.Features.Branches.Dtos;
using CommerceSystem.Application.Features.Branches.Queries.GetBranches;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommerceSystem.Api.Controllers
{
    [Route("api/branches")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BranchesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BranchDto>> Create(
            CreateBranchCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }


        [HttpGet]
        public async Task<ActionResult<List<BranchDto>>> GetAll([FromQuery] GetBranchesQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }
    }
}
