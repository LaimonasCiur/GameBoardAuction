using GameBoardAuction.Common.Models;
using GameBoardAuction.Repositories.Repositories.Contracts;
using GameBoardAuction.Services.Contracts;
using System.Threading.Tasks;

namespace GameBoardAuction.Services.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;

        public AuctionService(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public Task<AuctionDetails> AddAuction(AuctionDetails details, string addedBy)
        {
            throw new System.NotImplementedException();
        }
    }
}
