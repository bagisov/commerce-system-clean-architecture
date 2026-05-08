using CommerceSystem.Application.Features.ProductCategories.Commands.CreateProductCategory;
using CommerceSystem.Application.Features.ProductCategories.Commands.DeleteProductCateogry;
using CommerceSystem.Application.Features.ProductCategories.Commands.UpdateProductCategory;
using CommerceSystem.Application.Features.ProductCategories.Dtos;
using CommerceSystem.Application.Features.ProductCategories.Queries.GetProductCategories;
using CommerceSystem.Application.Features.ProductCategories.Queries.GetProductCategoryById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommerceSystem.Api.Controllers
{
    [Route("api/product-categories")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ProductCategoryDto>> Create(CreateProductCategoryCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }


        [HttpGet]
        public async Task<ActionResult<List<ProductCategoryDto>>> GetAll( CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductCategoriesQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategoryDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductCategoryByIdQuery { Id = id }, cancellationToken);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteProductCategoryCommand { Id = id }, cancellationToken);

            if (!result)
                return NotFound();

            return NoContent();
        }


        [HttpPut]
        public async Task<ActionResult<ProductCategoryDto>> Update(UpdateProductCategoryCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
