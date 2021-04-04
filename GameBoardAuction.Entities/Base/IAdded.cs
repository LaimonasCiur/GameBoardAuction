using System;

namespace GameBoardAuction.Entities.Base
{
    interface IAdded
    {
        int? AddedBy { get; set; }
        DateTime? AddedDate { get; set; }
    }
}
