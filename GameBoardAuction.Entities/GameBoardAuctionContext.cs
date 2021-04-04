using GameBoardAuction.Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace GameBoardAuction.Entities
{
    public class GameBoardAuctionContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public GameBoardAuctionContext(DbContextOptions<GameBoardAuctionContext> options) : base(options) { }
    }
}
