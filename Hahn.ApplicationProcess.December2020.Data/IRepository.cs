using Hahn.ApplicationProcess.December2020.Data.DAO;
using System.Collections.Generic;

namespace Hahn.ApplicationProcess.December2020.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
