using CommerceSystem.Application.Interfaces;
using CommerceSystem.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.Features.ProductCategories.Commands.DeleteProductCateogry
{
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand, bool>
    {
        private readonly IProductCategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCategoryCommandHandler(IProductCategoryRepository repository, IUnitOfWork unitOfWork)   
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken) 
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                return false;
            }

            await _repository.DeleteAsync(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
