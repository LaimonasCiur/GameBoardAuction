using GameBoardAuction.Entities.Models;
using System.Linq;
using System.Threading.Tasks;

namespace GameBoardAuction.Repositories.Repositories.Contracts
{
    public interface IThreadRepository
    {
        Task<Thread> AddThread(Thread entity, string addedBy);
        IQueryable<Thread> GetThreadsByUserId(string userId);
    }
}
