using GameBoardAuction.Entities.Models;
using System;
using System.ComponentModel.DataAnnotations;

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

        public static AuctionDetails FormAuctionDetails(Auction entity)
        {
            return new AuctionDetails
            {
                Name = entity.Name,
                Description = entity.Description,
                ActiveDate = entity.ActiveDate,
                BuyNowPrice = entity.BuyNowPrice,
                MinBidPrice = entity.MinBidPrice,
                StartingPrice = entity.StartingPrice,
                CreatedDate = entity.AddedDate.Value,
                Id = entity.Id
            };
        }

        public bool IsValidPrice() => BuyNowPrice > StartingPrice && BuyNowPrice > StartingPrice;
        public bool IsValidDate() => ActiveDate > DateTime.Now;
    }
}
