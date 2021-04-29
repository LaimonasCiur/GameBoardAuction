using GameBoardAuction.Entities;
using GameBoardAuction.Entities.Models;
using GameBoardAuction.Repositories.Base;
using GameBoardAuction.Repositories.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBoardAuction.Repositories.Repositories
{
    public class AuctionBetRepository : BaseRepository<AuctionBet>, IAuctionBetRepository
    {
        public AuctionBetRepository(GameBoardAuctionContext context) : base(context) { }

        public Task<AuctionBet> AddAuctionBet(AuctionBet entity, string addedBy)
        {
            entity.AddedBy = addedBy;
            entity.AddedDate = DateTime.UtcNow;

            return Add(entity);
        }

        public IQueryable<AuctionBet> GetAuctionBetsById(int id)
        {
            return _context.AuctionBets
                .Where(bet => bet.AuctionId == id).AsQueryable();
        }

        public IEnumerable<AuctionBet> GetBetsByUserId(string userId)
        {
            return _context.AuctionBets.Where(bet => bet.AddedBy.Equals(userId));
        }

        public AuctionBet GetMaxAuctionBet(int id)
        {
            return _context.AuctionBets.Where(bet => bet.AuctionId == id)
                .OrderByDescending(bet => bet.Value)
                .FirstOrDefault();
        }
    }
}
