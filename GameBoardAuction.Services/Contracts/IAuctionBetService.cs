using GameBoardAuction.Common.Models;
using GameBoardAuction.Entities.Models;
using System.Threading.Tasks;

namespace GameBoardAuction.Services.Contracts
{
    public interface IAuctionBetService
    {
        Task<AuctionBet> AddAuctionBet(AuctionBetDetails details);
    }
}
