using System.ComponentModel.DataAnnotations;

namespace GameBoardAuction.Common.Models
{
    public class MessageDTO
    {
        [Required]
        [StringLength(500, ErrorMessage = "Message is too long!")]
        public string Message { get; set; }
        public string AddedBy { get; set; }
    }
}
