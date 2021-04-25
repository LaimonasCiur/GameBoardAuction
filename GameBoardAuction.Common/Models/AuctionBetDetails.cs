using GameBoardAuction.Entities.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameBoardAuction.Common.Models
{
    public class AuctionBetDetails
    {
        [Required]
        public decimal BetValue { get; set; }
        public int AuctionId { get; set; }
        public DateTime AddedDate { get; set; }

        public static AuctionBet FormAuctionBet(AuctionBetDetails details) 
        {
            return new AuctionBet
            {
                Value = details.BetValue,
                AuctionId = details.AuctionId
            };
        }

        public static AuctionBetDetails FormAuctionBetDetails(AuctionBet details) 
        {
            return new AuctionBetDetails
            {
                BetValue = details.Value,
                AddedDate = details.AddedDate.Value
            };
        }
    }
}
