using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Data.Interface
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        Task<List<T>> GetAll();

        Task<T> Get(string id);

        Task<bool> Create(T item);

        Task<bool> Delete(T id);

    }
}
