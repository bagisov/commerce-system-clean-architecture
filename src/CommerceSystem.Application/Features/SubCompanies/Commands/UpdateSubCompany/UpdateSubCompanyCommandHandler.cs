using CommerceSystem.Application.Features.SubCompanies.Dtos;
using CommerceSystem.Application.Interfaces;
using CommerceSystem.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.SubCompanies.Commands.UpdateSubCompany
{
    public class UpdateSubCompanyCommandHandler : IRequestHandler<UpdateSubCompanyCommand, SubCompanyDto?>
    {
        private readonly ISubCompanyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public  UpdateSubCompanyCommandHandler(ISubCompanyRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SubCompanyDto?> Handle(UpdateSubCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(request.Name))
                entity.Name = request.Name;

            if (request.Status.HasValue)
                entity.Status = request.Status.Value;

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
