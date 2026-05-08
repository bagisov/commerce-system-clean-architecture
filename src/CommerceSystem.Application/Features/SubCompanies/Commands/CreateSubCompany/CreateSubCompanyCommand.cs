using CommerceSystem.Application.Features.SubCompanies.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.SubCompanies.Commands.CreateSubCompany
{
    public class CreateSubCompanyCommand : IRequest<SubCompanyDto>
    {
        public string Name { get; set; } = null!;
    }
}
