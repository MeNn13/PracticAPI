using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Data.Interface
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        Task<ActionResult<IEnumerable<T>>> GetAll();
        T Get(string id);
        void Create(T item);
        void Update(T item);
        void Delete(string id);
        void Save();
    }
}
