using System;

namespace GameBoardAuction.Entities.Base
{
    interface IAdded
    {
        string AddedBy { get; set; }
        DateTime? AddedDate { get; set; }
    }
}
