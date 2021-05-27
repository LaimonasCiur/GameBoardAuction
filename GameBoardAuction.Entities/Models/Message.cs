using GameBoardAuction.Entities.Base;
using System;

namespace GameBoardAuction.Entities.Models
{
    public class Message : IEntity, IAdded
    {
        public int Id { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public int ThreadId { get; set; }
        public string Content { get; set; }
    }
}
