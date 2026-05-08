using CommerceSystem.Application.Features.SubCompanies.Commands.CreateSubCompany;
using CommerceSystem.Application.Features.SubCompanies.Commands.DeleteSubCompany;
using CommerceSystem.Application.Features.SubCompanies.Commands.UpdateSubCompany;
using CommerceSystem.Application.Features.SubCompanies.Dtos;
using CommerceSystem.Application.Features.SubCompanies.Queries.GetSubCompanies;
using CommerceSystem.Application.Features.SubCompanies.Queries.GetSubCompanyById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace CommerceSystem.Api.Controllers
{
    [Route("api/sub-companies")]
    [ApiController]
    public class SubCompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SubCompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<SubCompanyDto>> Create(CreateSubCompanyCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubCompanyDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetSubCompanyByIdQuery { Id = id }, cancellationToken);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<SubCompanyDto>>>  GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetSubCompaniesQuery(), cancellationToken);
           
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteSubCompanyCommand { Id = id }, cancellationToken);

            if (!result)
            {
                return NotFound();
            }
            return NoContent();

        }

        [HttpPut]
        public async Task<ActionResult<SubCompanyDto>> Update(UpdateSubCompanyCommand request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }



    }
}
