using CommerceSystem.Application.Interfaces;
using CommerceSystem.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.SubCompanies.Commands.DeleteSubCompany
{
    public class DeleteSubCompanyCommandHandler : IRequestHandler<DeleteSubCompanyCommand, bool>
    {
        private readonly ISubCompanyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSubCompanyCommandHandler(ISubCompanyRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteSubCompanyCommand request, CancellationToken cancellationToken)
        {
            var entitiy = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (entitiy == null)
            {
                return false;
            }
            _repository.Delete(entitiy);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
