using Canducci.Pagination;
using ClubeAss.Domain;
using ClubeAss.Domain.Interface.Repository;
using ClubeAss.Repository.Ef.Base;
using ClubeAss.Repository.Ef.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<PaginatedRest<Customer>> GetAllAsync(int? page)
        {
            page ??= 1;
            if (page <= 0) page = 1;

            var result = await _customer
               .AsNoTracking()
               .OrderBy(c => c.Id)
               .ToPaginatedRestAsync(page.Value, 10);
            
            return result;

        }
    }
}
