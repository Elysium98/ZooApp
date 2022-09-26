using AutoMapper;
using Bissoft.Interview.Data.Entities;
using Bissoft.Interview.Services.Models;

namespace Bissoft.Interview.Services
{
    public class BussinesProfile : Profile
    {
        public BussinesProfile()
        {
            CreateMap<ZooKeeper, ZooKeeperEntity>();
            CreateMap<ZooKeeperEntity, ZooKeeper>();
            CreateMap<Animal, AnimalEntity>();
            CreateMap<AnimalEntity, Animal>();
        }
    }
}
