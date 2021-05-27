using GameBoardAuction.Entities.Base;
using System;

namespace GameBoardAuction.Entities.Models
{
    public class Thread : IEntity, IAdded
    {
        public int Id { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public string Topic { get; set; }
        public string RecievedBy { get; set; }
        public bool IsRead { get; set; }
    }
}
