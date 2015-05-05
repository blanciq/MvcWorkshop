using System.Collections.Generic;

namespace MvcWorkshops.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Save(T news);
    }
}