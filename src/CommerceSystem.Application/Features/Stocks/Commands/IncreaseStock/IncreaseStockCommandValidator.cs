using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Stocks.Commands.IncreaseStock
{
    public class IncreaseStockCommandValidator
           : AbstractValidator<IncreaseStockCommand>
    {
        public IncreaseStockCommandValidator()
        {
            RuleFor(x => x.BranchId)
                .NotEmpty();

            RuleFor(x => x.Items)
                .NotNull()
                .NotEmpty();

            RuleForEach(x => x.Items)
                .ChildRules(item =>
                {
                    item.RuleFor(x => x.ProductVariantId)
                        .NotEmpty();

                    item.RuleFor(x => x.Quantity)
                        .GreaterThan(0);
                });

            RuleFor(x => x.Note)
                .MaximumLength(500);
        }
    }
}
