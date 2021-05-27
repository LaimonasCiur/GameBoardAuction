using GameBoardAuction.Common.Models;
using System.Threading.Tasks;

namespace GameBoardAuction.Services.Contracts
{
    public interface IUserService
    {
        Task<string> GetCurrentUserId();
        Task<string> GetCurrentUserEmail();
        string GetUserEmailById(string userId);
        UserProfileDetails GetUserProfileDetails(string userId);
    }
}
