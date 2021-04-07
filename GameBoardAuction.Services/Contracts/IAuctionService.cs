using GameBoardAuction.Common.Models;
using System.Threading.Tasks;

namespace GameBoardAuction.Services.Contracts
{
    public interface IAuctionService
    {
        Task<AuctionDetails> AddAuction(AuctionDetails details, string addedBy);
    }
}
