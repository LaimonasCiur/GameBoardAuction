using BlazorInputFile;
using GameBoardAuction.Common.Models;
using GameBoardAuction.Entities.Models;
using GameBoardAuction.Repositories.Repositories.Contracts;
using GameBoardAuction.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBoardAuction.Services.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IUserService _userService;
        private readonly IAuctionBetRepository _auctionBetRepository;

        public AuctionService(
            IAuctionRepository auctionRepository, 
            IUserService userService, 
            IAuctionBetRepository auctionBetRepository)
        {
            _auctionRepository = auctionRepository;
            _userService = userService;
            _auctionBetRepository = auctionBetRepository;
        }

        public async Task<Auction> AddAuctionWithAttachments(AuctionDetails details, IFileListEntry[] selectedFiles)
        {
            var userId = await _userService.GetCurrentUserId();
          
            var auctionTask = _auctionRepository.AddAuction(AuctionDetails.FormAuction(details), userId);

            await Task.WhenAll(auctionTask);

            return auctionTask.Result;
        }

        public IEnumerable<AuctionDetails> GetAllAuctions()
        {
            var auctions = _auctionRepository.GetAuctions();

            return auctions.Select(auction => AuctionDetails.FormAuctionDetails(auction));
        }

        public async Task<AuctionDetails> GetAuctionById(int id) 
        {
            var auction = await _auctionRepository.GetById(id);
            var auctionBets = _auctionBetRepository.GetAuctionBetsById(id).ToList();

            return AuctionDetails.FormAuctionDetailsWithBets(auction, auctionBets);
        }

        public async Task<Auction> UpdateAuction(int id)
        {
            var auction = await _auctionRepository.GetById(id);
            var userId = await  _userService.GetCurrentUserId();

            auction.ActiveDate = new DateTime();
            auction.BoughtNowBy = userId;

            var updatedAuction = await _auctionRepository.Update(auction);

            return updatedAuction;
        }
    }
}
