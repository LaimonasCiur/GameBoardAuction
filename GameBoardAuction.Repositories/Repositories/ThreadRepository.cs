using GameBoardAuction.Common.Models;
using GameBoardAuction.Entities;
using GameBoardAuction.Entities.Models;
using GameBoardAuction.Repositories.Base;
using GameBoardAuction.Repositories.Repositories.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GameBoardAuction.Repositories.Repositories
{
    public class ThreadRepository : BaseRepository<Thread>, IThreadRepository
    {
        public ThreadRepository(GameBoardAuctionContext context) : base(context) { }

        public Task<Thread> AddThread(Thread entity, string addedBy)
        {
            entity.AddedBy = addedBy;
            entity.AddedDate = DateTime.UtcNow;

            return Add(entity);
        }

        public IQueryable<Thread> GetThreadsByUserId(string userId)
        { 
            return _context.Threads.Where(thread => thread.AddedBy.Equals(userId) || thread.RecievedBy.Equals(userId));
        }
    }
}
