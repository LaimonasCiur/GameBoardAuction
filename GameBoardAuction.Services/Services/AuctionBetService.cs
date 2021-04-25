using GameBoardAuction.Common.Models;
using GameBoardAuction.Entities.Models;
using GameBoardAuction.Repositories.Repositories.Contracts;
using GameBoardAuction.Services.Contracts;
using System.Threading.Tasks;

namespace GameBoardAuction.Services.Services
{
    public class AuctionBetService : IAuctionBetService
    {
        private readonly IUserService _userService;
        private readonly IAuctionBetRepository _auctionBetRepository;

        public AuctionBetService(
            IUserService userService,
            IAuctionBetRepository auctionBetRepository)
        {
            _userService = userService;
            _auctionBetRepository = auctionBetRepository;
        }

        public async Task<AuctionBet> AddAuctionBet(AuctionBetDetails details)
        {
            var userId = await _userService.GetCurrentUserId();
            var highestBet = _auctionBetRepository.GetMaxAuctionBet(details.AuctionId);

            details.BetValue += highestBet.Value;

            var auctionBet = await _auctionBetRepository.AddAuctionBet(AuctionBetDetails.FormAuctionBet(details), userId);

            return auctionBet;
        }
    }
}
