using System.Collections.Generic;

namespace Bissoft.Interview.Data.Entities
{
    public class ZooKeeperEntity : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<AnimalEntity> Animals { get; set; }
    }
}
