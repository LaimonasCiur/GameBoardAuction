using GameBoardAuction.Entities.Models;
using GameBoardAuction.Repositories.Base.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBoardAuction.Repositories.Repositories.Contracts
{
    public interface IAuctionBetRepository : IBaseRepository<AuctionBet>
    {
        Task<AuctionBet> AddAuctionBet(AuctionBet entity, string addedBy);
        IQueryable<AuctionBet> GetAuctionBetsById(int id);
        AuctionBet GetMaxAuctionBet(int id);
        IEnumerable<AuctionBet> GetBetsByUserId(string userId);
    }
}
