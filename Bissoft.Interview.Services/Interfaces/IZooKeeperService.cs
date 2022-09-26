using Bissoft.Interview.Data.Entities;
using Bissoft.Interview.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bissoft.Interview.Services.Interfaces
{
    public interface IZooKeeperService
    {
        void Add(ZooKeeper zooKeeper);
        IList<ZooKeeper> GetAll();

        bool Delete(int id);

        bool Update(int id, ZooKeeper zooKeeper);

        ZooKeeper FindById(int id);

    }
}
