using Microsoft.EntityFrameworkCore;
using Practic.Data.Interface;
using Practic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Data.Repository
{
    public class ClassroomRepository : IRepository<Classroom>
    {
        private ApplicationDbContext _context;

        public ClassroomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(Classroom item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Classroom id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Classroom Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Classroom>> GetAll()
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepository<Classroom>.Create(Classroom item)
        {
            throw new NotImplementedException();
        }


        Task<Classroom> IRepository<Classroom>.Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}
