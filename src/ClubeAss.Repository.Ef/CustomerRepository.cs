using ClubeAss.Domain;
using ClubeAss.Domain.Interface.Repository;
using ClubeAss.Repository.Ef.Base;
using ClubeAss.Repository.Ef.Context;
using Microsoft.EntityFrameworkCore;

namespace ClubeAss.Repository.Ef
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {

        private readonly DbSet<Customer> _customer;
        protected readonly BaseContext Db;


        public CustomerRepository(BaseContext dbContext) : base(dbContext)
        {
            Db = dbContext;
            _customer = dbContext.Set<Customer>();
        }
    }
}
