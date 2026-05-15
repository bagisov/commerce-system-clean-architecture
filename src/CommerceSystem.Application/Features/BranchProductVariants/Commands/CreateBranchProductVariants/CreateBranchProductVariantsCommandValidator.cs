using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.BranchProductVariants.Commands.CreateBranchProductVariants
{
    public class CreateBranchProductVariantsCommandValidator : AbstractValidator<CreateBranchProductVariantsCommand>
    {
        public CreateBranchProductVariantsCommandValidator()
        {
            RuleFor(x => x.BranchId)
                .NotEmpty();

            RuleFor(x => x.ProductVariantIds)
                .NotNull()
                .NotEmpty();

            RuleForEach(x => x.ProductVariantIds)
                .NotEmpty();
        }
    }
}
