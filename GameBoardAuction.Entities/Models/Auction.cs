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
        public decimal StartingPrice { get; set; }
        public decimal MinBidPrice { get; set; }
        public DateTime ActiveDate { get; set; }
        public string BoughtNowBy { get; set; }
        public bool IsVerified { get; set; }
    }
}
