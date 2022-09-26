using Bissoft.Interview.Data.Entities;
using Bissoft.Interview.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Bissoft.Interview.Data.Implementation
{
    public class ZooKeeperRepository : BaseRepository<ZooKeeperEntity>, IZooKeeperRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ZooKeeperRepository(ApplicationDbContext applicationDbContext)
             : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

    }
}
