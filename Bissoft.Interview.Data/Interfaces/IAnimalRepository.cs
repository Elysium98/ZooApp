using Bissoft.Interview.Data.Entities;
using System.Collections.Generic;

namespace Bissoft.Interview.Data.Interfaces
{
    public interface IAnimalRepository : IBaseRepository<AnimalEntity>
    {
        IEnumerable<AnimalEntity> GetAllByZooKeeperId(int id);

        IEnumerable<AnimalEntity> GetAllWithZooKeeper();

    }
}
