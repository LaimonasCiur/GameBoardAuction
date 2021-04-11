using GameBoardAuction.Common.Configuration;
using GameBoardAuction.Services.Contracts;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace GameBoardAuction.Services.Services
{
    public class UserService : IUserService
    {
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ConfigurationSettings _config;

        public UserService(IServiceProvider serviceProvider, AuthenticationStateProvider authStateProvider)
        {
            _authStateProvider = authStateProvider;
            _config = serviceProvider.GetService<ConfigurationSettings>();
        }

        public async Task<string> GetCurrentUserId()
        {
            var user = await _authStateProvider.GetAuthenticationStateAsync();
            return user.User.Claims.Single(claim => claim.Type.Equals(_config.IdentityServer.IdIdentifier)).Value;
        }
    }
}
