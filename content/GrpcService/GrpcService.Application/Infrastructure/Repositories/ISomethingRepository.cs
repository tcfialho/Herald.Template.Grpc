using Herald.EntityFramework.Repositories;

using GrpcService.Application.Entities;

namespace GrpcService.Application.Infrastructure.Repositories
{
    public interface ISomethingRepository : IRepository<Something>
    {
    }
}
