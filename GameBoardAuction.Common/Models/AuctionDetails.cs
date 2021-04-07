using System;

namespace GameBoardAuction.Common.Models
{
    public class AuctionDetails
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BuyNowPrice { get; set; }
        public DateTime ActiveDate { get; set; }
    }
}
