using GameBoardAuction.Entities.Base;
using System;

namespace GameBoardAuction.Entities.Models
{
    public class Auction : IEntity, IAdded
    {
        public int Id { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BuyNowPrice { get; set; }
        public DateTime ActiveDate { get; set; }
    }
}
