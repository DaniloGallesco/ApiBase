using ClubeAss.API.Customer.Validators.Customer;
using ClubeAss.API.Customer.ViewModel.Customer;
using FluentValidation.TestHelper;
using System;
using Xunit;

namespace ClubeAss.Test.UnitTest.Domain.Customer
{
    public class CustomerDeleteRequestTest
    {
        private CustomerDeleteRequestValidator validator;

        public CustomerDeleteRequestTest()
        {
            validator = new CustomerDeleteRequestValidator();
        }

        [Fact]
        public void IdSucesso()
        {
            var model = new CustomerDeleteRequest(Guid.NewGuid());
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.Id);
        }

    }
}
