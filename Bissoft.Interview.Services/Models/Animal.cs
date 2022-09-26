using Bissoft.Interview.Data.Entities;
using System;

namespace Bissoft.Interview.Services.Models
{
    public class Animal : BaseModel
    {

        public AType AnimalType { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int ZooKeeperId { get; set; }

        public ZooKeeper ZooKeeper { get; set; }
    }
}
