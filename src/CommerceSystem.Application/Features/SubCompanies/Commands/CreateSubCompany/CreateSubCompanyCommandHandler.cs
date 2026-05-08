using CommerceSystem.Application.Features.SubCompanies.Dtos;
using CommerceSystem.Application.Interfaces;
using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Common;
using CommerceSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace CommerceSystem.Application.Features.SubCompanies.Commands.CreateSubCompany
{
    public class CreateSubCompanyCommandHandler : IRequestHandler<CreateSubCompanyCommand, SubCompanyDto>
    {
        private readonly ISubCompanyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSubCompanyCommandHandler(ISubCompanyRepository repository, IUnitOfWork unitOfWork) 
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SubCompanyDto> Handle(CreateSubCompanyCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.ExistsByNameAsync(request.Name, cancellationToken);

            if (exists)
            {
                throw new Exception("Sub Company already exists");
            }

            var entity = new SubCompany
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Status = EntityStatus.Active
            };

            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new SubCompanyDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Status = entity.Status                
            };
        }
    }
}
