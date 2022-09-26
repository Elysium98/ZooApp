using Bissoft.Interview.Data.Entities;
using Bissoft.Interview.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Bissoft.Interview.Data.Implementation
{
    public class AnimalRepository : BaseRepository<AnimalEntity>, IAnimalRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AnimalRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public IEnumerable<AnimalEntity> GetAllWithZooKeeper()
        {
            return _dbContext.Animals
              .Include(z => z.ZooKeeper)
              .ToList();
        }

        public IEnumerable<AnimalEntity> GetAllByZooKeeperId(int zooKeeperId)
        {
            return _dbContext.Animals
            .Where(a => a.ZooKeeperId == zooKeeperId)
            .Include(b => b.ZooKeeper)
            .AsEnumerable();
        }
    }
}


