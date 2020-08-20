
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        T Get(int id);
        void Update(T item);
        void Delete(int id);
    }
}
