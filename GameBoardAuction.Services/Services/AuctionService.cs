using BlazorInputFile;
using GameBoardAuction.Common.Models;
using GameBoardAuction.Entities.Models;
using GameBoardAuction.Repositories.Repositories.Contracts;
using GameBoardAuction.Services.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace GameBoardAuction.Services.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IAttachmentService _attachmentService;
        private readonly IUserService _userService;

        public AuctionService(
            IAuctionRepository auctionRepository, 
            IUserService userService, 
            IAttachmentService attachmentService)
        {
            _auctionRepository = auctionRepository;
            _userService = userService;
            _attachmentService = attachmentService;
        }

        public async Task<Auction> AddAuctionWithAttachments(AuctionDetails details, IFileListEntry[] selectedFiles)
        {
            var userId = await _userService.GetCurrentUserId();
          
            var auctionTask = _auctionRepository.AddAuction(AuctionDetails.FormAuction(details), userId);

            await Task.WhenAll(auctionTask);

            return auctionTask.Result;
        }
    }
}
