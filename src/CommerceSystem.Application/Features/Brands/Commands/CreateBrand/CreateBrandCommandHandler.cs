using CommerceSystem.Application.Features.Brands.Dtos;
using CommerceSystem.Application.Interfaces;
using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, BrandDto>
    {
        private readonly IBrandRepository _repository;
        private readonly ISubCompanyRepository _subCompanyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBrandCommandHandler(IBrandRepository repository,ISubCompanyRepository subCompanyRepository, IUnitOfWork unitOfWork)   
        {
            _repository = repository;
            _subCompanyRepository = subCompanyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brandexists = await _repository.ExistsByNameAsync(request.Name, cancellationToken);
            if (brandexists)
            {
                throw new Exception("Brand already exists");
            }

            var subCompanyExists = await _subCompanyRepository.ExistsByIdAsync(request.SubCompanyId, cancellationToken);
            if (!subCompanyExists)
            {
                throw new Exception("Sub-company does not exist");
            }

            var now = DateTime.UtcNow;

            var entity = new Brand
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                SubCompanyId = request.SubCompanyId,
                JoinedSubCompanyAtUtc = now,
                Status = Common.EntityStatus.Active
            };

            await _repository.AddAsync(entity, cancellationToken);
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new BrandDto
            {
                Id = entity.Id,
                Name = entity.Name,
                SubCompanyId = entity.SubCompanyId,
                JoinedSubCompanyAtUtc = entity.JoinedSubCompanyAtUtc,
                Status = entity.Status
            };
        }
    }
}
