using System.Collections.Generic;

using Herald.Result;
using MediatR;

using GrpcApi.Application.Entities;

namespace GrpcApi.Application.Features.GetFromDataBase
{
    public partial class GetFromDataBaseCommand : IRequest<Result<IList<Something>>>
    {
    }
}