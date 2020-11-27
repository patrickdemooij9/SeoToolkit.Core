using System.Collections.Generic;
using System.Linq;
using SeoToolkit.Core.Interfaces;

namespace SeoToolkit.Core.Repositories
{
    public abstract class BaseMemoryRepository<T> : IRepository<T> where T : IEntityWithIdentity
    {
        protected List<T> Items { get; set; }

        public BaseMemoryRepository()
        {
            Items = new List<T>();
        }

        public void Add(T model)
        {
            Items.Add(model);
        }

        public void Delete(int id)
        {
            Items.Remove(Get(id));
        }

        public T Get(int id)
        {
            return Items.FirstOrDefault(it => it.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return Items;
        }

        public void Update(T model)
        {
            //Nothing?
        }
    }
}
