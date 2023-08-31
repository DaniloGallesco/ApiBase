using AutoMapper;
using ClubeAss.API.Customer.ViewModel.Customer;
using ClubeAss.Application.CommandHandlers;
using ClubeAss.Domain;
using ClubeAss.Domain.Commands;
using ClubeAss.Domain.Interface.Repository;
using ClubeAss.Domain.Repository.IBase;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace ClubeAss.Test.UnitTest.Application
{
    public class CustomerApplicationTest
    {
        private Mock<ICustomerRepository> CustomerRepositoryMoq;
        private Mock<IMapper> imapperMoq;
        private Mock<IUnitOfWork> _IUnitOfWork;
        private Mock<ILogger<CustomerHandler>> _log;

        public CustomerApplicationTest()
        {
            CustomerRepositoryMoq = new Mock<ICustomerRepository>();
            imapperMoq = new Mock<IMapper>();
            _IUnitOfWork = new Mock<IUnitOfWork>();
            _log = new Mock<ILogger<CustomerHandler>>();
        }


        [Fact]
        public void AddSucesso()
        {
            var guid = Guid.NewGuid();

            imapperMoq.Setup(x => x.Map<CustomerAddRequest, Customer>(It.IsAny<CustomerAddRequest>()))
               .Returns(new Customer() { Nome = "Nome_" + guid.ToString(), Id = guid });

            CustomerRepositoryMoq.Setup(x => x.AddAsync(It.IsAny<Customer>()));

            var result = new CustomerHandler(CustomerRepositoryMoq.Object, _IUnitOfWork.Object, imapperMoq.Object, _log.Object)
                 .Handle(new CustomerAddRequest() { Nome = guid.ToString() }, new System.Threading.CancellationToken()).Result;

            Assert.True(result.StatusCode == System.Net.HttpStatusCode.NoContent);
        }

        [Fact]
        public void UpdateSucesso()
        {
            var guid = Guid.NewGuid();
            imapperMoq.Setup(x => x.Map<CustomerUpdateRequest, Customer>(It.IsAny<CustomerUpdateRequest>()))
                           .Returns(new Customer() { Nome = "Nome_" + guid.ToString(), Id = guid });


            CustomerRepositoryMoq.Setup(x => x.UpdateAsync(It.IsAny<Customer>()));

            var result = new CustomerHandler(CustomerRepositoryMoq.Object, _IUnitOfWork.Object, imapperMoq.Object, _log.Object)
                 .Handle(new CustomerUpdateRequest() { Nome = guid.ToString() }, new System.Threading.CancellationToken()).Result;

            Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public void UpdateNotExist()
        {
            var guid = Guid.NewGuid();
            imapperMoq.Setup(x => x.Map<CustomerUpdateRequest, Customer>(It.IsAny<CustomerUpdateRequest>()))
                           .Returns(new Customer() { Nome = "Nome_" + guid.ToString(), Id = guid });

            CustomerRepositoryMoq.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Customer)null);

            CustomerRepositoryMoq.Setup(x => x.UpdateAsync(It.IsAny<Customer>()));

            var result = new CustomerHandler(CustomerRepositoryMoq.Object, _IUnitOfWork.Object, imapperMoq.Object, _log.Object)
                 .Handle(new CustomerUpdateRequest() { Nome = guid.ToString() }, new System.Threading.CancellationToken()).Result;

            Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public void GetByIdNotExist()
        {
            var guid = Guid.NewGuid();
            CustomerRepositoryMoq.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Customer)null);

            var result = new CustomerHandler(CustomerRepositoryMoq.Object, _IUnitOfWork.Object, imapperMoq.Object, _log.Object)
                .Handle(new CustomerGetRequest(guid), new System.Threading.CancellationToken()).Result;


            Assert.Null(result);
        }

        [Fact]
        public void GetAllNotExist()
        {
            var guid = Guid.NewGuid();
            CustomerRepositoryMoq.Setup(x => x.GetAllAsync()).ReturnsAsync((List<Customer>)null);

            imapperMoq.Setup(x => x.Map<IEnumerable<CustomerResponse>>(It.IsAny<IEnumerable<Customer>>()))
                          .Returns((IEnumerable<CustomerResponse>)null);


            var result = new CustomerHandler(CustomerRepositoryMoq.Object, _IUnitOfWork.Object, imapperMoq.Object, _log.Object)
             .Handle(new CustomerListRequest(), new System.Threading.CancellationToken()).Result;


            Assert.Null(result);
        }

        [Fact]
        public void GetAllExist()
        {
            var guid = Guid.NewGuid();
            CustomerRepositoryMoq.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<Customer>() { new Customer() { Id = guid, Nome = "Nome_" + guid.ToString() } });

            imapperMoq.Setup(x => x.Map<IEnumerable<CustomerResponse>>(It.IsAny<IEnumerable<Customer>>()))
                          .Returns(new List<CustomerResponse>() { new CustomerResponse() { Id = guid, Nome = "Nome_" + guid.ToString() } });

            var result = new CustomerHandler(CustomerRepositoryMoq.Object, _IUnitOfWork.Object, imapperMoq.Object, _log.Object)
            .Handle(new CustomerListRequest(), new System.Threading.CancellationToken()).Result;

            Assert.NotNull(result);
        }

        [Fact]
        public void RemoveExist()
        {
            var guid = Guid.NewGuid();
            CustomerRepositoryMoq.Setup(x => x.DeleteAsync(It.IsAny<Customer>()));

            CustomerRepositoryMoq.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new Customer() { Id = guid, Nome = "NOme" + guid.ToString() });

            var result = new CustomerHandler(CustomerRepositoryMoq.Object, _IUnitOfWork.Object, imapperMoq.Object, _log.Object)
            .Handle(new CustomerDeleteRequest(guid), new System.Threading.CancellationToken()).Result;

            Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public void RemoveNotExist()
        {
            var guid = Guid.NewGuid();
            CustomerRepositoryMoq.Setup(x => x.DeleteAsync(It.IsAny<Customer>()));

            CustomerRepositoryMoq.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Customer)null);


            var result = new CustomerHandler(CustomerRepositoryMoq.Object, _IUnitOfWork.Object, imapperMoq.Object, _log.Object)
           .Handle(new CustomerListRequest(), new System.Threading.CancellationToken()).Result;

            Assert.NotNull(result);
        }
    }
}
