using Bissoft.Interview.Data.Entities;
using System.Collections.Generic;

namespace Bissoft.Interview.Data.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        IEnumerable<T> FindAll();
    }
}
