using CommerceSystem.Application.Features.ProductCategories.Dtos;
using CommerceSystem.Common;
using MediatR;

namespace CommerceSystem.Application.Features.ProductCategories.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommand : IRequest<ProductCategoryDto>
    {
        public string Name{ get; set; } = null!;
    }
}
