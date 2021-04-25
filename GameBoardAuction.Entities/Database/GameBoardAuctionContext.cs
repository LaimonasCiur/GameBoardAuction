using GameBoardAuction.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace GameBoardAuction.Entities
{
    public class GameBoardAuctionContext : DbContext
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<AuctionBet> AuctionBets { get; set; }

        public GameBoardAuctionContext(DbContextOptions<GameBoardAuctionContext> options) : base(options) { }
    }
}
