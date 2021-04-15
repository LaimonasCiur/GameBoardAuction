using BlazorInputFile;
using GameBoardAuction.Common.Models;
using GameBoardAuction.Entities.Models;
using System.Threading.Tasks;

namespace GameBoardAuction.Services.Contracts
{
    public interface IAuctionService
    {
        Task<Auction> AddAuctionWithAttachments(AuctionDetails details, IFileListEntry[] selectedFiles);
    }
}
