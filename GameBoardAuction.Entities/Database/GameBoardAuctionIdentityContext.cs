using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameBoardAuction.Data
{
    public class GameBoardAuctionIdentityContext : IdentityDbContext
    {
        public GameBoardAuctionIdentityContext(DbContextOptions<GameBoardAuctionIdentityContext> options) : base(options) { }
    }
}
