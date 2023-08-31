using System.Threading.Tasks;

namespace ClubeAss.Domain.Repository.IBase
{
    public interface IUnitOfWork
    {

        void BeginTransaction();

        Task<bool> Commit();

        Task<bool> Rollback();
    }
}