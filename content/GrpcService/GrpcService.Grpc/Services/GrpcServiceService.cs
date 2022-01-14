using Grpc.Core;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
#if (!noexternalapi)
using GrpcService.Application.Features.GetAddressByPostalCode;
#endif
#if (!nodatabase)
using GrpcService.Application.Features.GetFromDataBase;
#endif
#if (!noqueue)
using GrpcService.Application.Features.SendToQueue;
#endif

namespace GrpcService.Grpc
{
    public class GrpcServiceService : GrpcService.GrpcServiceBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<GrpcServiceService> _logger;
        public GrpcServiceService(IMediator mediator, ILogger<GrpcServiceService> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

#if (!nodatabase)
        public override async Task<GetFromDataBaseResponse> GetFromDataBase(GetFromDataBaseRequest request, ServerCallContext context)
        {
            var command = new GetFromDataBaseCommand();
            var result = await _mediator.Send(command);
            var response = new GetFromDataBaseResponse();
            response.Somethings.AddRange(result.GetValue().Adapt<Something[]>());
            return response;
        }
#endif

#if (!noqueue)
        public override async Task<SendToQueueResponse> SendToQueue(SendToQueueRequest request, ServerCallContext context)
        {
            var command = request.Adapt<SendToQueueCommand>();
            var result = await _mediator.Send(command);
            var respose = result.GetValue().Adapt<SendToQueueResponse>();
            return respose;
        }
#endif

#if (!noexternalapi)
        public override async Task<GetFromExternalApiResponse> GetFromExternalApi(GetFromExternalApiRequest request, ServerCallContext context)
        {
            var command = request.Adapt<GetFromExternalApiCommand>();
            var result = await _mediator.Send(command);
            var respose = result.GetValue().Adapt<GetFromExternalApiResponse>();
            return respose;
        }
#endif
    }
}
