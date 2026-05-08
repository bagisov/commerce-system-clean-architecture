using CommerceSystem.Application.Features.ProductCategories.Commands.CreateProductCategory;
using CommerceSystem.Application.Interfaces;
using CommerceSystem.Application.Interfaces.Repositories;
using CommerceSystem.Common;
using CommerceSystem.Domain.Entities;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Tests.Unit.ProductCategories
{
    public class CreateProductCategoryCommandHandlerTests
    {
        private readonly Mock<IProductCategoryRepository> _repositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly CreateProductCategoryCommandHandler _handler;

        public CreateProductCategoryCommandHandlerTests()
        {
            _repositoryMock = new Mock<IProductCategoryRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _handler = new CreateProductCategoryCommandHandler(
                _repositoryMock.Object,
                _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateCategory_WhenNameIsUnique()
        {
            _repositoryMock
                .Setup(x => x.ExistsByNameAsync("Electronics"))
                .ReturnsAsync(false);

            _repositoryMock
                .Setup(x => x.AddAsync(It.IsAny<ProductCategory>()))
                .Returns(Task.CompletedTask);

            _unitOfWorkMock
                .Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var command = new CreateProductCategoryCommand
            {
                Name = "Electronics"
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
            result.Id.Should().NotBeEmpty();
            result.Name.Should().Be("Electronics");
            result.Status.Should().Be(EntityStatus.Active);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenCategoryAlreadyExists()
        {
            _repositoryMock
                .Setup(x => x.ExistsByNameAsync("Electronics"))
                .ReturnsAsync(true);

            var command = new CreateProductCategoryCommand
            {
                Name = "Electronics"
            };

            Func<Task> act = async () =>
                await _handler.Handle(command, CancellationToken.None);

            await act.Should()
                .ThrowAsync<Exception>()
                .WithMessage("Category already exists");
        }
    }
}
