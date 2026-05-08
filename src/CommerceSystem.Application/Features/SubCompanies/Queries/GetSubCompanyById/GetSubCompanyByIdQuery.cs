using CommerceSystem.Application.Features.SubCompanies.Dtos;
using FluentValidation.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.SubCompanies.Queries.GetSubCompanyById
{
    public class GetSubCompanyByIdQuery : IRequest<SubCompanyDto>
    {
        public Guid Id { get; set; }
    }
}
