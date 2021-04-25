using GameBoardAuction.Common.Models;
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
    public class AuctionRepository : BaseRepository<Auction>, IAuctionRepository
    {
        public AuctionRepository(GameBoardAuctionContext context) : base(context) { }

        public async Task<Auction> AddAuction(Auction entity, string addedBy)
        {
            entity.AddedBy = addedBy;
            entity.AddedDate = DateTime.UtcNow;

            return await Add(entity);
        }

        public List<Auction> GetAuctions()
        {
            return _context.Auctions.ToList();
        }

        public ValueTask<Auction> GetById(int id)
        {
            return _context.Auctions.FindAsync(id);
        }
    }
}
