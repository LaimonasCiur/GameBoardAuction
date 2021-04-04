using GameBoardAuction.Entities.Base;

namespace GameBoardAuction.Entities.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
