using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductVariants.Commands.CreateProductVariants
{
    public class CreateProductVariantsCommandValidator
    : AbstractValidator<CreateProductVariantsCommand>
    {
        public CreateProductVariantsCommandValidator()
        {
            RuleFor(x => x.ProductModelId)
                .NotEmpty();

            RuleFor(x => x.PurchasePrice)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.BaseSellingPrice)
                .GreaterThanOrEqualTo(0);
        }
    }
}
