using CommerceSystem.Application.Features.SubCompanies.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.SubCompanies.Queries.GetSubCompanies
{
    public class GetSubCompaniesQuery : IRequest<List<SubCompanyDto>>
    {
    }
}
