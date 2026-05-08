using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.SubCompanies.Commands.UpdateSubCompany
{
    public class UpdateSubCompanyCommandValidator : AbstractValidator<UpdateSubCompanyCommand>
    {
        public UpdateSubCompanyCommandValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Sub Company Id can not be null");

            RuleFor(x => x.Name)
                .NotEmpty()
                .When(x => x.Name != null);

            RuleFor(x=> x.Status)
                .IsInEnum()
                .When(x=> x.Status.HasValue);
        }
    }
}
