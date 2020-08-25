using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        T Get(int id);
        void Update(T item, int id);
        void Delete(int id);
        IEnumerable<T> GetAll();

    }
}
