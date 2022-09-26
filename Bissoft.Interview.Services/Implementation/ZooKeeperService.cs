using AutoMapper;
using Bissoft.Interview.Data.Entities;
using Bissoft.Interview.Data.Interfaces;
using Bissoft.Interview.Services.Interfaces;
using Bissoft.Interview.Services.Models;
using System.Collections.Generic;


namespace Bissoft.Interview.Services.Implementation
{
    public class ZooKeeperService : IZooKeeperService
    {
        private readonly IZooKeeperRepository _zooKeeperRepository;
        private readonly IMapper _mapper;


        public ZooKeeperService(
            IZooKeeperRepository zooKeeperRepository,
            IMapper mapper)
        {
            _zooKeeperRepository = zooKeeperRepository;
            _mapper = mapper;

        }

        public void Add(ZooKeeper zooKeeper)
        {
            _zooKeeperRepository.Create(_mapper.Map<ZooKeeperEntity>(zooKeeper));
        }

        public IList<ZooKeeper> GetAll()
        {
            var all = _zooKeeperRepository.FindAll();

            return _mapper.Map<List<ZooKeeper>>(all);
        }


        public ZooKeeper FindById(int id)
        {
            var zooKeeper = _zooKeeperRepository.GetById(id);
            var result = _mapper.Map<ZooKeeper>(zooKeeper);

            return result;
        }

        public bool Delete(int id)
        {
            var zooKeeper = _zooKeeperRepository.GetById(id);

            if (zooKeeper == null)
            {
                return false;
            }

            _zooKeeperRepository.Delete(zooKeeper);

            return true;

        }

        public bool Update(int id, ZooKeeper model)
        {
            var zooKeeper = _zooKeeperRepository.GetById(id);

            if (zooKeeper == null)
            {
                return false;
            }

            zooKeeper.Name = model.Name;

            _zooKeeperRepository.Update(zooKeeper);

            return true;

        }


    }
}
