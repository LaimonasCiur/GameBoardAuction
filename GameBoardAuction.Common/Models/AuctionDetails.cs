using GameBoardAuction.Entities.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameBoardAuction.Common.Models
{
    public class AuctionDetails
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Description is too long!")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, 99999, ErrorMessage = "Price cannot be lower than 0.01 or bigger than 99999")]
        public decimal BuyNowPrice { get; set; }
        [Required]
        public DateTime ActiveDate { get; set; }

        public static Auction FormAuction(AuctionDetails details)
        {
            return new Auction
            {
                Name = details.Name,
                Description = details.Description,
                BuyNowPrice = details.BuyNowPrice,
                ActiveDate = details.ActiveDate
            };
        }
    }
}
