using ClubeAss.API.Customer.Controllers.V1;
using ClubeAss.API.Customer.ViewModel.Customer;
using ClubeAss.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace ClubeAss.Test.UnitTest.Apis
{
    public class CustomerControllerTest
    {

        private Mock<IMediator> _mediator;

        public CustomerControllerTest()
        {
            _mediator = new Mock<IMediator>();
        }


        [Fact]
        public void GetAlSucesso()
        {
            var guid = Guid.NewGuid();

            _mediator
                .Setup(m => m.Send(It.IsAny<CustomerListRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse(System.Net.HttpStatusCode.OK) { Content = new { Id = guid, Nome = "Nome_" + guid.ToString() } });

            var result = new CustomerController(_mediator.Object).List().Result as ObjectResult;

            Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK.GetHashCode());
            Assert.NotNull(result.Value);
        }


        [Fact]
        public void GetAllNotExist()
        {

            _mediator
                .Setup(m => m.Send(It.IsAny<CustomerListRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse(System.Net.HttpStatusCode.NoContent) { Content = null });

            var result = new CustomerController(_mediator.Object).List().Result as ObjectResult;

            Assert.True(result.StatusCode == System.Net.HttpStatusCode.NoContent.GetHashCode());
            Assert.Null(((BaseResponse)result.Value).Content);

        }

        [Fact]
        public void AddSucesso()
        {
            _mediator
             .Setup(m => m.Send(It.IsAny<CustomerAddRequest>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(new BaseResponse(System.Net.HttpStatusCode.OK, null));

            var result = new CustomerController(_mediator.Object).Post(new CustomerAddRequest()).Result as ObjectResult;

            Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK.GetHashCode());
            Assert.Null(((BaseResponse)result.Value).Content);
        }

        [Fact]
        public void AddBadRequest()
        {
            _mediator
           .Setup(m => m.Send(It.IsAny<CustomerAddRequest>(), It.IsAny<CancellationToken>()))
           .ReturnsAsync(new BaseResponse(System.Net.HttpStatusCode.BadRequest, null));

            var result = new CustomerController(_mediator.Object).Post(new CustomerAddRequest()).Result as ObjectResult;

            Assert.True(result.StatusCode == System.Net.HttpStatusCode.BadRequest.GetHashCode());
            Assert.Null(((BaseResponse)result.Value).Content);
        }

        [Fact]
        public void UpdateSucesso()
        {
            _mediator
            .Setup(m => m.Send(It.IsAny<CustomerUpdateRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BaseResponse(System.Net.HttpStatusCode.OK, null));

            var result = new CustomerController(_mediator.Object).Put(Guid.NewGuid(), new CustomerUpdateRequestViewModel()).Result as ObjectResult;

            Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK.GetHashCode());
            Assert.Null(((BaseResponse)result.Value).Content);

        }

        [Fact]
        public void UpadteBadRequestValidate()
        {
            _mediator
              .Setup(m => m.Send(It.IsAny<CustomerUpdateRequest>(), It.IsAny<CancellationToken>()))
              .ReturnsAsync(new BaseResponse(System.Net.HttpStatusCode.BadRequest, null));

            var result = new CustomerController(_mediator.Object).Put(Guid.NewGuid(),new CustomerUpdateRequestViewModel()).Result as ObjectResult;


            Assert.True(result.StatusCode == System.Net.HttpStatusCode.BadRequest.GetHashCode());
            Assert.Null(((BaseResponse)result.Value).Content);

        }


        //[Fact]
        //public void UpadteBadRequestNotExist()
        //{
        //    customerApplicationMoq.Setup(x => x.Update(It.IsAny<Guid>(), It.IsAny<CustomerUpdateRequest>())).ReturnsAsync(new BaseResponse(System.Net.HttpStatusCode.BadRequest, null, new List<string>() { "Erro" }));

        //    validatorCustomerUpdateRequestValidatorMoq.Setup(x => x.ValidateAsync(It.IsAny<CustomerUpdateRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult());

        //    var result = new CustomerController(customerApplicationMoq.Object, validatorCustomerAddRequestMoq.Object, validatorCustomerDeleteRequestValidatorMoq.Object, validatorCustomerGetRequestValidatorMoq.Object, validatorCustomerUpdateRequestValidatorMoq.Object, _cache)
        //        .Put(Guid.NewGuid(), null).Result as ObjectResult;

        //    Assert.True(result.StatusCode == System.Net.HttpStatusCode.BadRequest.GetHashCode());
        //    Assert.NotNull(((BaseResponse)result.Value).Message);
        //}




        //[Fact]
        //public void RemoveSucesso()
        //{
        //    customerApplicationMoq.Setup(x => x.Remove(It.IsAny<CustomerDeleteRequest>())).ReturnsAsync(new BaseResponse(System.Net.HttpStatusCode.OK, null));

        //    validatorCustomerDeleteRequestValidatorMoq.Setup(x => x.ValidateAsync(It.IsAny<CustomerDeleteRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult());

        //    var result = new CustomerController(customerApplicationMoq.Object, validatorCustomerAddRequestMoq.Object, validatorCustomerDeleteRequestValidatorMoq.Object, validatorCustomerGetRequestValidatorMoq.Object, validatorCustomerUpdateRequestValidatorMoq.Object, _cache)
        //        .Delete(Guid.NewGuid()).Result as StatusCodeResult;

        //    Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK.GetHashCode());
        //}

        //[Fact]
        //public void RemoveBadRequestValidate()
        //{
        //    validatorCustomerDeleteRequestValidatorMoq.Setup(x => x.ValidateAsync(It.IsAny<CustomerDeleteRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("Nome", "Erro qualquer") }));

        //    var result = new CustomerController(customerApplicationMoq.Object, validatorCustomerAddRequestMoq.Object, validatorCustomerDeleteRequestValidatorMoq.Object, validatorCustomerGetRequestValidatorMoq.Object, validatorCustomerUpdateRequestValidatorMoq.Object, _cache)
        //        .Delete(Guid.NewGuid()).Result as ObjectResult;

        //    Assert.True(result.StatusCode == System.Net.HttpStatusCode.BadRequest.GetHashCode());
        //    Assert.NotNull(((BaseResponse)result.Value).Message);
        //}

        //[Fact]
        //public void RemoveBadRequestNotExist()
        //{
        //    customerApplicationMoq.Setup(x => x.Remove(It.IsAny<CustomerDeleteRequest>())).ReturnsAsync(new BaseResponse(System.Net.HttpStatusCode.BadRequest, null, new List<string>() { "Erro" }));

        //    validatorCustomerDeleteRequestValidatorMoq.Setup(x => x.ValidateAsync(It.IsAny<CustomerDeleteRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult());

        //    var result = new CustomerController(customerApplicationMoq.Object, validatorCustomerAddRequestMoq.Object, validatorCustomerDeleteRequestValidatorMoq.Object, validatorCustomerGetRequestValidatorMoq.Object, validatorCustomerUpdateRequestValidatorMoq.Object, _cache)
        //        .Delete(Guid.NewGuid()).Result as ObjectResult;

        //    Assert.True(result.StatusCode == System.Net.HttpStatusCode.BadRequest.GetHashCode());
        //    Assert.NotNull(((BaseResponse)result.Value).Message);
        //}


        [Fact]
        public void GetByIdSucesso()
        {
            var guid = Guid.NewGuid();

            _mediator
               .Setup(m => m.Send(It.IsAny<CustomerGetRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse(System.Net.HttpStatusCode.OK, new BaseResponse(System.Net.HttpStatusCode.OK) { Content = new { Id = guid, Nome = "Nome_" + guid.ToString() } }));

            var result = new CustomerController(_mediator.Object).Get(guid).Result as ObjectResult;


            Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK.GetHashCode());
            Assert.NotNull(result.Value);
        }

        [Fact]
        public void GetByIdSucessoNotExist()
        {
            var guid = Guid.NewGuid();

            _mediator
               .Setup(m => m.Send(It.IsAny<CustomerGetRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse(System.Net.HttpStatusCode.BadRequest));

            var result = new CustomerController(_mediator.Object).Get(guid).Result as ObjectResult;

            Assert.True(result.StatusCode == System.Net.HttpStatusCode.BadRequest.GetHashCode());
            Assert.Null(((BaseResponse)result.Value).Content);
        }

    }
}
