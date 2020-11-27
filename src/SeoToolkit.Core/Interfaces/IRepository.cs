using System.Collections.Generic;

namespace SeoToolkit.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T model);
        void Update(T model);
        void Delete(int id);
    }
}
