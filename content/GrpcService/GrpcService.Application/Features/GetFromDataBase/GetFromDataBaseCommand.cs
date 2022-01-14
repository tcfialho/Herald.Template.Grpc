using System.Collections.Generic;

using Herald.Result;
using MediatR;

using GrpcService.Application.Entities;

namespace GrpcService.Application.Features.GetFromDataBase
{
    public partial class GetFromDataBaseCommand : IRequest<Result<IList<Something>>>
    {
    }
}