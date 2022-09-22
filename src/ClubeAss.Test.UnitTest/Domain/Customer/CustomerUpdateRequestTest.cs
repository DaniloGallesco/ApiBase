using ClubeAss.API.Customer.Validators.Customer;
using ClubeAss.API.Customer.ViewModel.Customer;
using FluentValidation.TestHelper;
using Xunit;

namespace ClubeAss.Test.UnitTest.Domain.Customer
{
    public class CustomerUpdateRequestTest
    {
        private CustomerUpdateRequestValidator validator;

        public CustomerUpdateRequestTest()
        {
            validator = new CustomerUpdateRequestValidator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("1")]
        [InlineData("12")]
        [InlineData("123")]
        [InlineData("1234")]
        public void NomeError(string nome)
        {
            var model = new CustomerUpdateRequest { Nome = nome };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.Nome);
        }

        [Fact]
        public void NomeSucesso()
        {
            var model = new CustomerUpdateRequest { Nome = "12345" };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.Nome);
        }

    }
}
