using ClubeAss.API.Customer.Validators.Customer;
using ClubeAss.API.Customer.ViewModel.Customer;
using FluentValidation.TestHelper;
using System;
using Xunit;

namespace ClubeAss.Test.UnitTest.Domain.Customer
{
    public class CustomerGetRequestTest
    {
        private CustomerGetRequestValidator validator;

        public CustomerGetRequestTest()
        {
            validator = new CustomerGetRequestValidator();
        }

        [Fact]
        public void IdSucesso()
        {
            var model = new CustomerGetRequest(Guid.NewGuid());
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.Id);
        }

    }
}
