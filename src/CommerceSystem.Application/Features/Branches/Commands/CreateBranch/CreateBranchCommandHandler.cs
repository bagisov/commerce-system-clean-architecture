using CommerceSystem.Application.Features.Branches.Dtos;
using CommerceSystem.Application.Interfaces;
using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Common;
using CommerceSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.Branches.Commands.CreateBranch
{
    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, BranchDto>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBranchCommandHandler(IBranchRepository branchRepository,IBrandRepository brandRepository, IUnitOfWork unitOfWork)
        {
            _branchRepository = branchRepository;
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BranchDto> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(request.BrandId, cancellationToken);
            if (brand == null)
            {
                throw new Exception("Brand not found");
            }
            var exists = await _branchRepository
            .ExistsByNameAsync(request.Name, cancellationToken);

            if (exists)
            {
                throw new Exception("Branch already exists");
            }

            var entity = new Branch
            {
                Id = Guid.NewGuid(),
                BrandId = request.BrandId,
                Name = request.Name,
                Address = request.Address,
                Status = EntityStatus.Active,
                CreatedAtUtc = DateTime.UtcNow
            };

            await _branchRepository.AddAsync(entity, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new BranchDto
            {
                Id = entity.Id,
                BrandId = brand.Id,
                BrandName = brand.Name,
                Name = entity.Name,
                Address = entity.Address,
                Status = entity.Status,
                CreatedAtUtc = entity.CreatedAtUtc
            };


        }
    }
}
