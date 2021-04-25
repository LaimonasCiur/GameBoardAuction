using GameBoardAuction.Entities.Base;
using System;

namespace GameBoardAuction.Entities.Models
{
    public class AuctionBet : IEntity, IAdded
    {
        public int Id { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }

        public int AuctionId { get; set; }
        public decimal Value { get; set; }
    }
}
