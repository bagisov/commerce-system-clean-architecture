using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductModels.Commands.CreateProductModel
{
    public class CreateProductModelCommandValidator : AbstractValidator<CreateProductModelCommand>
    {
        public CreateProductModelCommandValidator()
        {
            RuleFor(x => x.BrandId)
                .NotEmpty();

            RuleFor(x => x.CategoryId)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}
