﻿#if (sqs || kafka || rabbitmq || azure)
using System.ComponentModel.DataAnnotations;

using Herald.Result;

using MediatR;

namespace GrpcApi.Application.Features.SendToQueue
{
    public partial class SendToQueueCommand : IRequest<Result>
    {
        [Required]
        public string Description { get; set; }
    }
}
#endif