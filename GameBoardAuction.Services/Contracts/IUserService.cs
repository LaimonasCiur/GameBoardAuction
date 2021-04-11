using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameBoardAuction.Services.Contracts
{
    public interface IUserService
    {
        Task<string> GetCurrentUserId();
    }
}
