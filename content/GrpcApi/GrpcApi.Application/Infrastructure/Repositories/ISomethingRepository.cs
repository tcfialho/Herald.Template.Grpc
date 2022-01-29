using Herald.EntityFramework.Repositories;

using GrpcApi.Application.Entities;

namespace GrpcApi.Application.Infrastructure.Repositories
{
    public interface ISomethingRepository : IRepository<Something>
    {
    }
}
