using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.SubCompanies.Commands.CreateSubCompany
{
    public class CreateSubCompanyCommandValidator : AbstractValidator<CreateSubCompanyCommand>
    {
        public CreateSubCompanyCommandValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Sub Company name is required")
                .MaximumLength(200)
                .WithMessage("Sub Company name cannot exceed 200 characters.");                
        }
    }
}
