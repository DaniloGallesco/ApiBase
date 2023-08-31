using ClubeAss.Domain;
using ClubeAss.Repository.Ef;
using ClubeAss.Repository.Ef.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace ClubeAss.Test.UnitTest.Repository
{
    public class CustomerRepositoryTest
    {
        private CustomerRepository CustomerRepositoryMoq;

        public CustomerRepositoryTest()
        {
            var dbName = $"ApiBase_{DateTime.Now.ToFileTimeUtc()}";

            DbContextOptions<BaseContext> DbContextOptionsMoq = new DbContextOptionsBuilder<BaseContext>()
             .UseInMemoryDatabase(dbName)
             .Options;

            CustomerRepositoryMoq = new CustomerRepository(new BaseContext(DbContextOptionsMoq));
        }


        [Fact]
        public async void AddSucesso()
        {

            Guid guid = Guid.NewGuid();
            var obj = new Customer() { Id = guid, Nome = "Nome_" + guid.ToString() };

            await CustomerRepositoryMoq.AddAsync(obj);

            var validar = CustomerRepositoryMoq.GetByIdAsync(guid).Result;

            Assert.True(validar.Id == guid && validar.Nome == "Nome_" + guid.ToString());
        }

        [Fact]
        public async void UpdateSucesso()
        {

            Guid guid = Guid.NewGuid();
            var obj = new Customer() { Id = guid, Nome = "Nome_" + guid.ToString() };

            await CustomerRepositoryMoq.AddAsync(obj);
            obj.Nome = "Nome_v2" + guid.ToString();

            await CustomerRepositoryMoq.UpdateAsync(obj);

            var validar = CustomerRepositoryMoq.GetByIdAsync(guid).Result;

            Assert.True(validar.Id == guid && validar.Nome == "Nome_v2" + guid.ToString());
        }

        [Fact]
        public async void UpdateNotExist()
        {
            Guid guid = Guid.NewGuid();
            var obj = new Customer() { Id = guid, Nome = "Nome_" + guid.ToString() };

            await Assert.ThrowsAsync<DbUpdateConcurrencyException>(async () => await CustomerRepositoryMoq.UpdateAsync(obj));
        }

        [Fact]
        public void GetByIdNotExist()
        {
            var result = CustomerRepositoryMoq.GetByIdAsync(Guid.NewGuid()).Result;

            Assert.Null(result);
        }

        [Fact]
        public async void GetAllNotExist()
        {
            var result = await CustomerRepositoryMoq.GetAllAsync();

            Assert.False(result.Any());
        }

        [Fact]
        public async void GetAllExist()
        {
            Guid guid = Guid.NewGuid();
            var obj = new Customer() { Id = guid, Nome = "Nome_" + guid.ToString() };

            await CustomerRepositoryMoq.AddAsync(obj);
            var result = CustomerRepositoryMoq.GetAllAsync().Result;

            Assert.True(result.Any() && result.Count() == 1);
        }

        [Fact]
        public async void RemoveExist()
        {
            Guid guid = Guid.NewGuid();
            var obj = new Customer() { Id = guid, Nome = "Nome_" + guid.ToString() };

            await CustomerRepositoryMoq.AddAsync(obj);
            await CustomerRepositoryMoq.DeleteAsync(obj);
            var result = CustomerRepositoryMoq.GetByIdAsync(guid).Result;

            Assert.Null(result);
        }

        [Fact]
        public async void RemoveNotExist()
        {
            Guid guid = Guid.NewGuid();
            var obj = new Customer() { Id = guid, Nome = "Nome_" + guid.ToString() };

            await Assert.ThrowsAsync<DbUpdateConcurrencyException>(() => CustomerRepositoryMoq.DeleteAsync(obj));
        }
    }
}
