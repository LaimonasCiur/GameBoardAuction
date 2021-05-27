using GameBoardAuction.Entities.Models;
using System.Linq;
using System.Threading.Tasks;

namespace GameBoardAuction.Repositories.Repositories.Contracts
{
    public interface IMessageRepository
    {
        Task<Message> AddMessage(Message entity, string addedBy);
        IQueryable<Message> GetMessagesByUserId(string userId);
        IQueryable<Message> GetMessagesByThreadId(int threadId);
    }
}
