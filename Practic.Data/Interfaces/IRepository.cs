using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Data.Interface
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        Task<List<T>> GetAll();

        T Get(string id);

        bool Create(T item);

        bool Delete(string id);

    }
}
