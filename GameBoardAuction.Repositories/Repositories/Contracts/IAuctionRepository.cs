using GameBoardAuction.Entities.Models;
using GameBoardAuction.Repositories.Base.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameBoardAuction.Repositories.Repositories.Contracts
{
    public interface IAuctionRepository : IBaseRepository<Auction>
    {
        ValueTask<Auction> GetById(int id);
        List<Auction> GetAuctions();
        Task<Auction> AddAuction(Auction entity, string addedBy);
    }
}
