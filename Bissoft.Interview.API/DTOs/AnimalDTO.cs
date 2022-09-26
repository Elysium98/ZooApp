using Bissoft.Interview.Data.Entities;
using System;

namespace Bissoft.Interview.API.DTOs
{
    public class AnimalDTO
    {
        public int Id { get; set; }
        public AType AnimalType { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int ZooKeeperId { get; set; }

        public ZooKeeperDTO ZooKeeper { get; set; }
    }
}
