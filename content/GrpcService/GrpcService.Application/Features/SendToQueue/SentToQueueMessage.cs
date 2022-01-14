using System;

using Herald.MessageQueue;

namespace GrpcService.Application.Features.SendToQueue
{
    public class SentToQueueMessage : MessageBase
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
