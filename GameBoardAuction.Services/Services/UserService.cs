using GameBoardAuction.Common.Configuration;
using GameBoardAuction.Services.Contracts;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using GameBoardAuction.Data;
using GameBoardAuction.Repositories.Repositories.Contracts;
using GameBoardAuction.Common.Models;

namespace GameBoardAuction.Services.Services
{
    public class UserService : IUserService
    {
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ConfigurationSettings _config;
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuctionRepository _auctionRepository;
        private readonly IAuctionBetRepository _auctionBetRepository;

        public UserService(IServiceProvider serviceProvider,
            AuthenticationStateProvider authStateProvider,
            IAuctionRepository auctionRepository,
            IAuctionBetRepository auctionBetRepository)
        {
            _authStateProvider = authStateProvider;
            _config = serviceProvider.GetService<ConfigurationSettings>();
            _serviceProvider = serviceProvider;
            _auctionRepository = auctionRepository;
            _auctionBetRepository = auctionBetRepository;
        }

        public async Task<string> GetCurrentUserId()
        {
            var user = await _authStateProvider.GetAuthenticationStateAsync();
            return user.User.Claims.Single(claim => claim.Type.Equals(_config.IdentityServer.IdIdentifier)).Value;
        }

        public async Task<string> GetCurrentUserEmail()
        {
            var user = await _authStateProvider.GetAuthenticationStateAsync();
            return user.User.Claims.Single(claim => claim.Type.Equals(_config.IdentityServer.EmailIdentifier)).Value;
        }

        public string GetUserEmailById(string userId) 
        {
            using (var scope = _serviceProvider.CreateScope()) 
            {
                var identityContext = scope.ServiceProvider.GetRequiredService<GameBoardAuctionIdentityContext>();
                var user = identityContext.Users.Single(user => user.Id.Equals(userId));

                return user.Email;
            }
        }

        public UserProfileDetails GetUserProfileDetails(string userId)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var identityContext = scope.ServiceProvider.GetRequiredService<GameBoardAuctionIdentityContext>();

                var user = identityContext.Users.Single(user => user.Id.Equals(userId));
                var userAuctions = _auctionRepository.GetAuctionByUserId(userId);
                var userBets = _auctionBetRepository.GetBetsByUserId(userId);

                return new UserProfileDetails
                {
                    UserEmail = user.UserName,
                    Auctions = userAuctions.Select(auction => AuctionDetails.FormAuctionDetails(auction)),
                    TotalMadeBets = userBets.Count()
                };
            }
        }
    }
}
