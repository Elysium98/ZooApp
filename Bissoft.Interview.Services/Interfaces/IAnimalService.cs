using Bissoft.Interview.Data.Entities;
using Bissoft.Interview.Services.Models;
using System.Collections.Generic;

namespace Bissoft.Interview.Services.Interfaces
{
    public interface IAnimalService
    {
        List<Animal> GetAll();

        void Add(Animal animal);

        IList<Animal> GetAllByZooKeeper(int id);

        bool Delete(int id);
    }
}
