using GameBoardAuction.Entities;
using GameBoardAuction.Entities.Models;
using GameBoardAuction.Repositories.Base;
using GameBoardAuction.Repositories.Repositories.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GameBoardAuction.Repositories.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(GameBoardAuctionContext context) : base(context) { }

        public Task<Message> AddMessage(Message entity, string addedBy) 
        {
            entity.AddedBy = addedBy;
            entity.AddedDate = DateTime.UtcNow;

            return Add(entity);
        }

        public IQueryable<Message> GetMessagesByThreadId(int threadId)
        {
            return _context.Messages.Where(message => message.ThreadId == threadId);
        }

        public IQueryable<Message> GetMessagesByUserId(string userId)
        {
            return _context.Messages.Where(message => message.AddedBy.Equals(userId));
        }
    }
}
