using GameBoardAuction.Common.Models;
using System.Threading.Tasks;

namespace GameBoardAuction.Services.Contracts
{
    public interface IUserService
    {
        Task<string> GetCurrentUserId();
        UserProfileDetails GetUserProfileDetails(string userId);
    }
}
