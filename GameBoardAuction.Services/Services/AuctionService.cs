using GameBoardAuction.Common.Models;
using GameBoardAuction.Entities.Models;
using GameBoardAuction.Repositories.Repositories.Contracts;
using GameBoardAuction.Services.Contracts;
using System.Threading.Tasks;

namespace GameBoardAuction.Services.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IUserService _userService;

        public AuctionService(IAuctionRepository auctionRepository, IUserService userService)
        {
            _auctionRepository = auctionRepository;
            _userService = userService;
        }

        public async Task<Auction> AddAuctionWithAttachments(AuctionDetails details)
        {
            var userId = await _userService.GetCurrentUserId();

            var auctionTask = _auctionRepository.AddAuction(AuctionDetails.FormAuction(details), userId);

            await Task.WhenAll(auctionTask);

            return auctionTask.Result;
        }
    }
}
