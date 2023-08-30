namespace ClubeAss.Test.UnitTest.Apis
{
    public class CustomerControllerTest
    {

        //private Mock<ICustomerApplication> customerApplicationMoq;
        //private Mock<IValidator<CustomerAddRequest>> validatorCustomerAddRequestMoq;
        //private Mock<IValidator<CustomerDeleteRequest>> validatorCustomerDeleteRequestValidatorMoq;
        //private Mock<IValidator<CustomerGetRequest>> validatorCustomerGetRequestValidatorMoq;
        //private Mock<IValidator<CustomerUpdateRequest>> validatorCustomerUpdateRequestValidatorMoq;
        //private IMemoryCache _cache;

        //public CustomerControllerTest()
        //{
        //    customerApplicationMoq = new Mock<ICustomerApplication>();
        //    validatorCustomerAddRequestMoq = new Mock<IValidator<CustomerAddRequest>>();
        //    validatorCustomerDeleteRequestValidatorMoq = new Mock<IValidator<CustomerDeleteRequest>>();
        //    validatorCustomerGetRequestValidatorMoq = new Mock<IValidator<CustomerGetRequest>>();
        //    validatorCustomerUpdateRequestValidatorMoq = new Mock<IValidator<CustomerUpdateRequest>>();

        //    var services = new ServiceCollection();
        //    services.AddMemoryCache();
        //    var serviceProvider = services.BuildServiceProvider();

        //    _cache = serviceProvider.GetService<IMemoryCache>();
        //}


        //[Fact]
        //public void GetAlSucesso()
        //{
        //    customerApplicationMoq.Setup(x => x.GetAll()).ReturnsAsync(new BaseResponse(System.Net.HttpStatusCode.OK, new List<CustomerResponse>()));

        //    var result = new CustomerController(customerApplicationMoq.Object, validatorCustomerAddRequestMoq.Object, validatorCustomerDeleteRequestValidatorMoq.Object, validatorCustomerGetRequestValidatorMoq.Object, validatorCustomerUpdateRequestValidatorMoq.Object, _cache).List().Result as ObjectResult;

        //    Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK.GetHashCode());
        //    Assert.NotNull(((BaseResponse)result.Value).Content);
        //}


        //[Fact]
        //public void GetAllNotExist()
        //{
        //    customerApplicationMoq.Setup(x => x.GetAll()).ReturnsAsync(new BaseResponse(System.Net.HttpStatusCode.OK, (List<CustomerResponse>)null));

        //    var result = new CustomerController(customerApplicationMoq.Object, validatorCustomerAddRequestMoq.Object, validatorCustomerDeleteRequestValidatorMoq.Object, validatorCustomerGetRequestValidatorMoq.Object, validatorCustomerUpdateRequestValidatorMoq.Object, _cache).List().Result as ObjectResult;

        //    Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK.GetHashCode());
        //    Assert.Null(((BaseResponse)result.Value).Content);
        //}

        //[Fact]
        //public void AddSucesso()
        //{
        //    customerApplicationMoq.Setup(x => x.Add(It.IsAny<CustomerAddRequest>())).ReturnsAsync(new BaseResponse(System.Net.HttpStatusCode.OK, null));

        //    validatorCustomerAddRequestMoq.Setup(x => x.ValidateAsync(It.IsAny<CustomerAddRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult());

        //    var result = new CustomerController(customerApplicationMoq.Object, validatorCustomerAddRequestMoq.Object, validatorCustomerDeleteRequestValidatorMoq.Object, validatorCustomerGetRequestValidatorMoq.Object, validatorCustomerUpdateRequestValidatorMoq.Object, _cache).Post(null).Result as StatusCodeResult;

        //    Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK.GetHashCode());
        //}

        //[Fact]
        //public void AddBadRequest()
        //{
        //    validatorCustomerAddRequestMoq.Setup(x => x.ValidateAsync(It.IsAny<CustomerAddRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("Nome", "Erro qualquer") }));

        //    var result = new CustomerController(customerApplicationMoq.Object, validatorCustomerAddRequestMoq.Object, validatorCustomerDeleteRequestValidatorMoq.Object, validatorCustomerGetRequestValidatorMoq.Object, validatorCustomerUpdateRequestValidatorMoq.Object, _cache).Post(null).Result as ObjectResult;

        //    Assert.True(result.StatusCode == System.Net.HttpStatusCode.BadRequest.GetHashCode());
        //    Assert.NotNull(((BaseResponse)result.Value).Message);
        //}

        //[Fact]
        //public void UpdateSucesso()
        //{
        //    customerApplicationMoq.Setup(x => x.Update(It.IsAny<Guid>(), It.IsAny<CustomerUpdateRequest>())).ReturnsAsync(new BaseResponse(System.Net.HttpStatusCode.OK, null));

        //    validatorCustomerUpdateRequestValidatorMoq.Setup(x => x.ValidateAsync(It.IsAny<CustomerUpdateRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult());

        //    var result = new CustomerController(customerApplicationMoq.Object, validatorCustomerAddRequestMoq.Object, validatorCustomerDeleteRequestValidatorMoq.Object, validatorCustomerGetRequestValidatorMoq.Object, validatorCustomerUpdateRequestValidatorMoq.Object, _cache)
        //        .Put(Guid.NewGuid(), null).Result as StatusCodeResult;

        //    Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK.GetHashCode());
        //}

        //[Fact]
        //public void UpadteBadRequestValidate()
        //{
        //    validatorCustomerUpdateRequestValidatorMoq.Setup(x => x.ValidateAsync(It.IsAny<CustomerUpdateRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("Nome", "Erro qualquer") }));

        //    var result = new CustomerController(customerApplicationMoq.Object, validatorCustomerAddRequestMoq.Object, validatorCustomerDeleteRequestValidatorMoq.Object, validatorCustomerGetRequestValidatorMoq.Object, validatorCustomerUpdateRequestValidatorMoq.Object, _cache)
        //        .Put(Guid.NewGuid(), null).Result as ObjectResult;

        //    Assert.True(result.StatusCode == System.Net.HttpStatusCode.BadRequest.GetHashCode());
        //    Assert.NotNull(((BaseResponse)result.Value).Message);
        //}


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
        //    customerApplicationMoq.Setup(x => x.Delete(It.IsAny<CustomerDeleteRequest>())).ReturnsAsync(new BaseResponse(System.Net.HttpStatusCode.OK, null));

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
        //    customerApplicationMoq.Setup(x => x.Delete(It.IsAny<CustomerDeleteRequest>())).ReturnsAsync(new BaseResponse(System.Net.HttpStatusCode.BadRequest, null, new List<string>() { "Erro" }));

        //    validatorCustomerDeleteRequestValidatorMoq.Setup(x => x.ValidateAsync(It.IsAny<CustomerDeleteRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult());

        //    var result = new CustomerController(customerApplicationMoq.Object, validatorCustomerAddRequestMoq.Object, validatorCustomerDeleteRequestValidatorMoq.Object, validatorCustomerGetRequestValidatorMoq.Object, validatorCustomerUpdateRequestValidatorMoq.Object, _cache)
        //        .Delete(Guid.NewGuid()).Result as ObjectResult;

        //    Assert.True(result.StatusCode == System.Net.HttpStatusCode.BadRequest.GetHashCode());
        //    Assert.NotNull(((BaseResponse)result.Value).Message);
        //}


        //[Fact]
        //public void GetByIdSucesso()
        //{

        //    customerApplicationMoq.Setup(x => x.GetByid(It.IsAny<CustomerGetRequest>())).ReturnsAsync(new BaseResponse(System.Net.HttpStatusCode.OK, new CustomerResponse() { }));

        //    validatorCustomerGetRequestValidatorMoq.Setup(x => x.ValidateAsync(It.IsAny<CustomerGetRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult());

        //    var result = new CustomerController(customerApplicationMoq.Object, validatorCustomerAddRequestMoq.Object, validatorCustomerDeleteRequestValidatorMoq.Object, validatorCustomerGetRequestValidatorMoq.Object, validatorCustomerUpdateRequestValidatorMoq.Object, _cache)
        //        .Get(Guid.NewGuid()).Result as ObjectResult;

        //    Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK.GetHashCode());
        //    Assert.NotNull(((BaseResponse)result.Value).Content);
        //}

        //[Fact]
        //public void GetByIdSucessoNotExist()
        //{
        //    customerApplicationMoq.Setup(x => x.GetByid(It.IsAny<CustomerGetRequest>())).ReturnsAsync(new BaseResponse(System.Net.HttpStatusCode.OK, null));

        //    validatorCustomerGetRequestValidatorMoq.Setup(x => x.ValidateAsync(It.IsAny<CustomerGetRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult());

        //    var result = new CustomerController(customerApplicationMoq.Object, validatorCustomerAddRequestMoq.Object, validatorCustomerDeleteRequestValidatorMoq.Object, validatorCustomerGetRequestValidatorMoq.Object, validatorCustomerUpdateRequestValidatorMoq.Object, _cache)
        //        .Get(Guid.NewGuid()).Result as ObjectResult;

        //    Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK.GetHashCode());
        //    Assert.Null(((BaseResponse)result.Value).Content);
        //}

    }
}
