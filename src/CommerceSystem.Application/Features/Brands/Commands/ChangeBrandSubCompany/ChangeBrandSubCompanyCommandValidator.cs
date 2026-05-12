using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Brands.Commands.ChangeBrandSubCompany
{
    public class ChangeBrandSubCompanyCommandValidator : AbstractValidator<ChangeBrandSubCompanyCommand>
    {
        public ChangeBrandSubCompanyCommandValidator()
        {
            RuleFor(x => x.BrandId)
                .NotEmpty()
                .WithMessage("Brand Id can not be null");

            RuleFor(x => x.NewSubCompanyId)
                .NotEmpty()
                .WithMessage("New Company Id can not be null");
        }
    }
}
