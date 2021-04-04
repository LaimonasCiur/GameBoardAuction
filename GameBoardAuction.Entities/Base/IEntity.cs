using System.ComponentModel.DataAnnotations;

namespace GameBoardAuction.Entities.Base
{
    public interface IEntity
    {
        [Key]
        int Id { get; set; }
    }
}
