using GameBoardAuction.Entities.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameBoardAuction.Common.Models
{
    public class MessageDetails
    {
        public string Topic { get; set; }
        public string Message { get; set; }
        public Guid RecievedBy { get; set; }
        public string AddedBy { get; set; }

        public static Message FormMessage(MessageDetails details, int threadId)
        {
            return new Message
            {
                Content = details.Message,
                ThreadId = threadId
            };
        }

        public static Thread FormThread(MessageDetails details, string recievedBy)
        {
            return new Thread
            {
                Topic = details.Topic,
                RecievedBy = recievedBy
            };
        }

        public static MessageDetails FormMessageDetails(Message message) 
        {
            return new MessageDetails
            {
                Message = message.Content,
                AddedBy = message.AddedBy
            };
        }
    }
}
