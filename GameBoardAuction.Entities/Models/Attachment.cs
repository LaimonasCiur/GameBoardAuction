using GameBoardAuction.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameBoardAuction.Entities.Models
{
    public class Attachment : IEntity, IAdded
    {
        public int Id { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }

        public int AuctionId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileUrl { get; set; }
    }
}
