using ClubeAss.Domain;
using ClubeAss.Domain.Enum.Base;
using ClubeAss.Domain.Interface.Application.Base;
using ClubeAss.Domain.Interface.Repository;
using ClubeAss.Repository.Ef.Base;
using ClubeAss.Repository.Ef.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClubeAss.Repository.Ef
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {

        private readonly DbSet<Customer> _customer;
        public CustomerRepository(BaseContext dbContext) : base(dbContext)
        {
            _customer = dbContext.Set<Customer>();
        }       
    }
}
