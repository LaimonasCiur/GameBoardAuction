using GameBoardAuction.Common.Models;
using GameBoardAuction.Data;
using GameBoardAuction.Entities.Models;
using GameBoardAuction.Repositories.Repositories.Contracts;
using GameBoardAuction.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBoardAuction.Services.Services
{
    public class AuctionBetService : IAuctionBetService
    {
        private readonly IUserService _userService;
        private readonly IAuctionBetRepository _auctionBetRepository;
        private readonly IServiceProvider _serviceProvider;

        public AuctionBetService(
            IUserService userService,
            IAuctionBetRepository auctionBetRepository,
            IServiceProvider serviceProvider)
        {
            _userService = userService;
            _auctionBetRepository = auctionBetRepository;
            _serviceProvider = serviceProvider;
        }

        public async Task<AuctionBet> AddAuctionBet(AuctionBetDetails details)
        {
            var userId = await _userService.GetCurrentUserId();
            var auctionBet = await _auctionBetRepository.AddAuctionBet(AuctionBetDetails.FormAuctionBet(details), userId);
            return auctionBet;
        }

        public List<AuctionBetHistory> GetAuctionBetHistories(int id)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var identityContext = scope.ServiceProvider.GetRequiredService<GameBoardAuctionIdentityContext>();

                var users = identityContext.Users.ToList();

                var betsByAuction = _auctionBetRepository.GetAuctionBetsById(id);

                var result = from user in users
                             join bet in betsByAuction on user.Id equals bet.AddedBy
                             orderby bet.AddedDate descending
                             select new AuctionBetHistory
                             {
                                 UserMail = user.Email,
                                 BetValue = bet.Value,
                                 AddedDate = bet.AddedDate.Value,
                                 UserId = Guid.Parse(user.Id)
                             };


                return result.ToList();
            }
        }
    }
}
