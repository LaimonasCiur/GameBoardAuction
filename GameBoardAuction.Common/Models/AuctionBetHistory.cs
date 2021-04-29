using System;

namespace GameBoardAuction.Common.Models
{
    public class AuctionBetHistory
    {
        public string UserMail { get; set; }
        public DateTime AddedDate { get; set; }
        public decimal BetValue { get; set; }
        public Guid UserId { get; set; }
    }
}
