using System.Collections.Generic;

namespace GameBoardAuction.Common.Models
{
    public class UserProfileDetails
    {
        public string UserEmail { get; set; }
        public IEnumerable<AuctionDetails> Auctions { get; set; }
        public int TotalMadeBets { get; set; }
    }
}
