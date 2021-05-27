using System.Collections.Generic;

namespace GameBoardAuction.Common.Models
{
    public class ThreadDetails
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public  List<MessageDetails> Messages { get; set; }
    }
}
