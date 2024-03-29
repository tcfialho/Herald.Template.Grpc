﻿#if (sqs || kafka || rabbitmq || azure)
using System.Threading;
using System.Threading.Tasks;

using Herald.MessageQueue;

using Herald.Result;

using Mapster;

using MediatR;

namespace GrpcApi.Application.Features.SendToQueue
{
    public class SendToQueueHandler : IRequestHandler<SendToQueueCommand, Result>
    {
        private readonly IMessageQueue _queue;

        public SendToQueueHandler(IMessageQueue queue)
        {
            _queue = queue;
        }

        public async Task<Result> Handle(SendToQueueCommand request, CancellationToken cancellationToken)
        {
            await _queue.Send(request.Adapt<SendToQueueMessage>());

            return ResultStatus.Sucess();
        }
    }
}
#endif