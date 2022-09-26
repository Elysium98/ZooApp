using System;

namespace Bissoft.Interview.Data.Entities
{
    public enum AType
    {
        Carnivorous,
        Omnivoruous,
        Herbivorous
    }

    public class AnimalEntity : BaseEntity
    {
        public AType AnimalType { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int ZooKeeperId { get; set; }

        public ZooKeeperEntity ZooKeeper { get; set; }
    }
}
