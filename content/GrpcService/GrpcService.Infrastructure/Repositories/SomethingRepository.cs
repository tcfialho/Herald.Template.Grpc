using System.Linq;

using Herald.EntityFramework.Repositories;

using Microsoft.EntityFrameworkCore;

using GrpcService.Application.Entities;
using GrpcService.Application.Infrastructure.Repositories;

namespace GrpcService.Infrastructure.Repositories
{
    public class SomethingRepository : Repository<Something>, ISomethingRepository
    {
        protected override IQueryable<Something> _query { get; set; }

        public SomethingRepository(DbContext context) : base(context)
        {
        }
    }
}
