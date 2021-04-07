using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameBoardAuction.Repositories.Base.Contracts
{
    public interface IBaseRepository<T> where T : class, new()
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
        Task Delete(IEnumerable<T> entities);
    }
}
