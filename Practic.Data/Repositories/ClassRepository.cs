using Microsoft.EntityFrameworkCore;
using Practic.Data.Interface;
using Practic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Data.Repository
{
    public class ClassRepository : IRepository<Class>
    {
        private ApplicationDbContext _context;

        public ClassRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(Class item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Class id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Class Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Class>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Class> Update(Class item)
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepository<Class>.Create(Class item)
        {
            throw new NotImplementedException();
        }

        Task<Class> IRepository<Class>.Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}
