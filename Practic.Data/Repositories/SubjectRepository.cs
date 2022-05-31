using Microsoft.EntityFrameworkCore;
using Practic.Data.Interface;
using Practic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Data.Repository
{
    public class SubjectRepository : IRepository<Subject>
    {
        private ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(Subject item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Subject id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Subject Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Subject>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Subject> Update(Subject item)
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepository<Subject>.Create(Subject item)
        {
            throw new NotImplementedException();
        }


        Task<Subject> IRepository<Subject>.Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}
