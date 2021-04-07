using GameBoardAuction.Entities;
using GameBoardAuction.Entities.Models;
using GameBoardAuction.Repositories.Base;
using GameBoardAuction.Repositories.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameBoardAuction.Repositories.Repositories
{
    public class AuctionRepository : BaseRepository<Auction>, IAuctionRepository
    {
        public AuctionRepository(GameBoardAuctionContext context) : base(context) { }

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
