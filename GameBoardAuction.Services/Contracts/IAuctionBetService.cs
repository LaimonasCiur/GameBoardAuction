using GameBoardAuction.Common.Models;
using GameBoardAuction.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameBoardAuction.Services.Contracts
{
    public interface IAuctionBetService
    {
        Task<AuctionBet> AddAuctionBet(AuctionBetDetails details);
        List<AuctionBetHistory> GetAuctionBetHistories(int id);
    }
}
