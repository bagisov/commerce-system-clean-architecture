using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.SubCompanies.Commands.DeleteSubCompany
{
    public class DeleteSubCompanyCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
