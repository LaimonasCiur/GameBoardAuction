using GameBoardAuction.Common.Models;
using GameBoardAuction.Entities;
using GameBoardAuction.Entities.Models;
using GameBoardAuction.Repositories.Base;
using GameBoardAuction.Repositories.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameBoardAuction.Repositories.Repositories
{
    public class AuctionRepository : BaseRepository<Auction>, IAuctionRepository
    {
        public AuctionRepository(GameBoardAuctionContext context) : base(context) { }

        public Task<Auction> AddAuction(Auction entity, string addedBy)
        {
            entity.AddedBy = addedBy;
            entity.AddedDate = DateTime.UtcNow;

            return Add(entity);
        }

        public Task<IEnumerable<Auction>> GetAuctions()
        {
            throw new NotImplementedException();
        }

        public Task<Auction> GetId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
