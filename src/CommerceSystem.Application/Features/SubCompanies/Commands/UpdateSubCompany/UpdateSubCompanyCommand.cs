using CommerceSystem.Application.Features.SubCompanies.Dtos;
using CommerceSystem.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.SubCompanies.Commands.UpdateSubCompany
{
    public class UpdateSubCompanyCommand : IRequest<SubCompanyDto>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public EntityStatus? Status { get; set; }
    }
}
