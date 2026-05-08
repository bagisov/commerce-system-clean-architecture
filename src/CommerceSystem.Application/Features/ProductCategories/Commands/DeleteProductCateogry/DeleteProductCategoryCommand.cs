using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductCategories.Commands.DeleteProductCateogry
{
    public class DeleteProductCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
