using AutoMapper;
using Bissoft.Interview.Data.Entities;
using Bissoft.Interview.Data.Interfaces;
using Bissoft.Interview.Services.Interfaces;
using Bissoft.Interview.Services.Models;
using System.Collections.Generic;
using System.Linq;


namespace Bissoft.Interview.Services.Implementation
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;


        public AnimalService(IAnimalRepository animalRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        public List<Animal> GetAll()
        {

            var all = _animalRepository.GetAllWithZooKeeper().ToList();


            return _mapper.Map<List<Animal>>(all);
        }

        public IList<Animal> GetAllByZooKeeper(int zooKeeperId)
        {

            var all = _animalRepository.GetAllByZooKeeperId(zooKeeperId).ToList();


            return _mapper.Map<List<Animal>>(all);

        }


        public void Add(Animal animal)
        {
            _animalRepository.Create(_mapper.Map<Animal, AnimalEntity>(animal));
        }

        public bool Delete(int id)
        {
            var animal = _animalRepository.GetById(id);

            if (animal == null)
            {
                return false;
            }

            _animalRepository.Delete(animal);

            return true;

        }


    }
}
