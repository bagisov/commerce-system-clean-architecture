using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator() 
        {
            RuleFor(x=> x.Name)
                .NotEmpty()
            .WithMessage("Brand name is required.")
            .MaximumLength(200)
            .WithMessage("Brand name cannot exceed 200 characters.");

            RuleFor(x => x.SubCompanyId)
                .NotEmpty()
                .WithMessage("Sub-company id is required.");
        }
    }
}
