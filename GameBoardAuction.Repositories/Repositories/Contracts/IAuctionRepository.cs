using GameBoardAuction.Common.Models;
using GameBoardAuction.Entities.Models;
using GameBoardAuction.Repositories.Base.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameBoardAuction.Repositories.Repositories.Contracts
{
    public interface IAuctionRepository : IBaseRepository<Auction>
    {
        Task<Auction> GetId(int id);
        Task<IEnumerable<Auction>> GetAuctions();
        Task<Auction> AddAuction(Auction detials, string addedBy);
    }
}
