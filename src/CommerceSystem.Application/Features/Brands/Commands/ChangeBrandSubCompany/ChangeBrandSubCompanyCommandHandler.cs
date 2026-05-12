using CommerceSystem.Application.Features.Brands.Dtos;
using CommerceSystem.Application.Interfaces;
using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Brands.Commands.ChangeBrandSubCompany
{
    public class ChangeBrandSubCompanyCommandHandler : IRequestHandler<ChangeBrandSubCompanyCommand, BrandDto?>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly ISubCompanyRepository _subCompanyRepository;
        private readonly IBrandSubCompanyHistoryRepository _subCompanyHistoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ChangeBrandSubCompanyCommandHandler(IBrandRepository brandRepository, ISubCompanyRepository subCompanyRepository, IBrandSubCompanyHistoryRepository subCompanyHistoryRepository, IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            _subCompanyRepository = subCompanyRepository;
            _subCompanyHistoryRepository = subCompanyHistoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BrandDto?> Handle(ChangeBrandSubCompanyCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(request.BrandId, cancellationToken);
            if (brand == null)
            {
                return null;
            }

            var newSubCompanyExists = await _subCompanyRepository.ExistsByIdAsync(request.NewSubCompanyId, cancellationToken);
            if (!newSubCompanyExists)
            {
                throw new Exception("New sub-company does not exist");
            }

            if (brand.SubCompanyId == request.NewSubCompanyId)
            {
                throw new Exception("Brand already belongs to this sub-company");
            }

            var now = DateTime.UtcNow;

            var history = new BrandSubCompanyHistory
            {
                Id = Guid.NewGuid(),
                BrandId = brand.Id,
                SubCompanyId = brand.SubCompanyId,
                EnteredAtUtc = brand.JoinedSubCompanyAtUtc,
                LeftAtUtc = now
            };

            await _subCompanyHistoryRepository.AddAsync(history, cancellationToken);

            brand.SubCompanyId = request.NewSubCompanyId;
            brand.JoinedSubCompanyAtUtc = now;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new BrandDto
            {
                Id = brand.Id,
                Name = brand.Name,
                SubCompanyId = brand.SubCompanyId,
                JoinedSubCompanyAtUtc = brand.JoinedSubCompanyAtUtc,
                Status = brand.Status
            };
        }
    }
}
