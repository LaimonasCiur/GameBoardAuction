using GameBoardAuction.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GameBoardAuction.Common.Models
{
    public class AuctionDetails
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Description is too long!")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, 99999, ErrorMessage = "Buy now price cannot be lower than 0.01 or bigger than 99999")]
        public decimal BuyNowPrice { get; set; }

        [Required]
        [Range(0.01, 99999, ErrorMessage = "Starting price cannot be lower than 0.01 or bigger than 99999")]
        public decimal StartingPrice { get; set; }

        [Required]
        [Range(0.01, 99999, ErrorMessage = "Minimum bid price cannot be lower than 0.01 or bigger than 99999")]
        public decimal MinBidPrice { get; set; }

        [Required]
        public DateTime ActiveDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public IEnumerable<AuctionBetDetails> AuctionBets { get; set; }

        public string AddedBy { get; set; }

        public bool IsVerified { get; set; }

        public static Auction FormAuction(AuctionDetails details)
        {
            return new Auction
            {
                Name = details.Name,
                Description = details.Description,
                BuyNowPrice = details.BuyNowPrice,
                MinBidPrice = details.MinBidPrice,
                StartingPrice = details.StartingPrice,
                ActiveDate = details.ActiveDate
            };
        }

        public static Auction FormAuctionBoughtNow(AuctionDetails details, string userId) 
        {
            var auction = FormAuction(details);
            auction.BoughtNowBy = userId;

            return auction;
        }

        public static AuctionDetails FormAuctionDetails(Auction entity)
        {
            return new AuctionDetails
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ActiveDate = entity.ActiveDate,
                BuyNowPrice = entity.BuyNowPrice,
                MinBidPrice = entity.MinBidPrice,
                StartingPrice = entity.StartingPrice,
                CreatedDate = entity.AddedDate.Value,
                IsVerified = entity.IsVerified
            };
        }

        public static AuctionDetails FormAuctionDetailsWithBets(Auction auction, IEnumerable<AuctionBet> auctionBets)
        {
            return new AuctionDetails
            {
                Id = auction.Id,
                Name = auction.Name,
                Description = auction.Description,
                ActiveDate = auction.ActiveDate,
                BuyNowPrice = auction.BuyNowPrice,
                MinBidPrice = auction.MinBidPrice,
                StartingPrice = auction.StartingPrice,
                CreatedDate = auction.AddedDate.Value,
                AddedBy = auction.AddedBy,
                AuctionBets = auctionBets.Select(bet => AuctionBetDetails.FormAuctionBetDetails(bet))
            };
        }

        public bool IsValidPrice() => BuyNowPrice > StartingPrice && BuyNowPrice > StartingPrice;
        public bool IsValidDate() => ActiveDate > DateTime.Now;
    }
}
