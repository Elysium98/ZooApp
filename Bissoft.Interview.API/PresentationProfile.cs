using AutoMapper;
using Bissoft.Interview.API.DTOs;
using Bissoft.Interview.Services.Models;

namespace Bissoft.Interview.API
{
    public class PresentationProfile: Profile
    {
        public PresentationProfile()
        {
            CreateMap<ZooKeeperDTO, ZooKeeper>();
            CreateMap<ZooKeeper, ZooKeeperDTO>();
            CreateMap<AnimalDTO, Animal>();
            CreateMap<Animal, AnimalDTO>();
        }
    }
}
