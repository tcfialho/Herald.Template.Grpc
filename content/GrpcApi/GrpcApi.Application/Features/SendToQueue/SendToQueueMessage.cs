﻿#if (sqs || kafka || rabbitmq || azure)
using System;

using Herald.MessageQueue;

namespace GrpcApi.Application.Features.SendToQueue
{
    public class SendToQueueMessage : MessageBase
    {
        public SendToQueueMessage()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public string Description { get; set; }
    }
}
#endif