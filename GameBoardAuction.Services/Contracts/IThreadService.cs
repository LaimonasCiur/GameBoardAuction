using GameBoardAuction.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameBoardAuction.Services.Contracts
{
    public interface IThreadService
    {
        Task CreateThreadAndMessage(MessageDetails details);
        List<MessageDetails> GetMessagesByThreadId(int threadId);
        Task AddMessageToThread(int threadId, MessageDetails details);
        Task<List<ThreadDetails>> GetThreadsAndMessagesByUserId();
    }
}
