using CommerceSystem.Application.Features.ProductCategories.Commands.CreateProductCategory;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Tests.Unit.ProductCategories
{
    public class CreateProductCategoryCommandValidatorTests
    {
        [Fact]
        public async Task Validator_ShouldFail_WhenNameIsEmpty()
        {
            var validator = new CreateProductCategoryCommandValidator();
            var command = new CreateProductCategoryCommand
            {
                Name = ""
            };

            var result = await validator.ValidateAsync(command);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Name");
        }

        [Fact]
        public async Task Validator_ShouldFail_WhenNameIsTooLong()
        {
            var validator = new CreateProductCategoryCommandValidator();

            var command = new CreateProductCategoryCommand
            {
                Name = new string('A', 201)
            };

            var result = await validator.ValidateAsync(command);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Validator_ShouldPass_WhenNameIsValid()
        {
            var validator = new CreateProductCategoryCommandValidator();

            var command = new CreateProductCategoryCommand
            {
                Name = "Electronics"
            };

            var result = await validator.ValidateAsync(command);

            result.IsValid.Should().BeTrue();
        }
    }
}
