using GameBoardAuction.Common.Models;
using GameBoardAuction.Repositories.Repositories.Contracts;
using GameBoardAuction.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBoardAuction.Services.Services
{
    public class ThreadService : IThreadService
    {
        private readonly IThreadRepository _threadRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IUserService _userService;

        public ThreadService(
            IThreadRepository threadRepository,
            IMessageRepository messageRepository,
            IUserService userService)
        {
            _threadRepository = threadRepository;
            _messageRepository = messageRepository;
            _userService = userService;
        }

        public async Task CreateThreadAndMessage(MessageDetails details)
        {
            var userEmail = await _userService.GetCurrentUserEmail();
            var recievedBy = _userService.GetUserEmailById(details.RecievedBy.ToString());

            var thread = await _threadRepository.AddThread(MessageDetails.FormThread(details, recievedBy), userEmail);

            await _messageRepository.AddMessage(MessageDetails.FormMessage(details, thread.Id), userEmail);
        }

        public async Task<List<ThreadDetails>> GetThreadsAndMessagesByUserId()
        {
            var currentUserMail = await _userService.GetCurrentUserEmail();

            var threads = _threadRepository.GetThreadsByUserId(currentUserMail);
            var messages = _messageRepository.GetMessagesByUserId(currentUserMail);

            return threads.Select(thread => new ThreadDetails
            {
                Id = thread.Id,
                Topic = thread.Topic,
                Messages = messages
                .Where(message => message.ThreadId == thread.Id)
                .Select(message => MessageDetails.FormMessageDetails(message)).ToList()
            }).ToList();
        }

        public async Task AddMessageToThread(int threadId, MessageDetails details)
        {
            var userId = await _userService.GetCurrentUserEmail();
            await _messageRepository.AddMessage(MessageDetails.FormMessage(details, threadId), userId);
        }

        public List<MessageDetails> GetMessagesByThreadId(int threadId)
        {
            return _messageRepository.GetMessagesByThreadId(threadId).Select(message => MessageDetails.FormMessageDetails(message)).ToList();
        }
    }
}
