using Canducci.Pagination;
using ClubeAss.Domain.Interface.Repository.IBase;
using System.Threading.Tasks;

namespace ClubeAss.Domain.Interface.Repository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<PaginatedRest<Customer>> GetAllAsync(int? page);
    }
}