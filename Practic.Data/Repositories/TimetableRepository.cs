using Microsoft.EntityFrameworkCore;
using Practic.Data.Interface;
using Practic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Data.Repository
{
    public class TimetableRepository : IRepository<Timetable>
    {
        private ApplicationDbContext _context;

        public TimetableRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(Timetable item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Timetable id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Timetable Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Timetable>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Timetable> Update(Timetable item)
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepository<Timetable>.Create(Timetable item)
        {
            throw new NotImplementedException();
        }


        Task<Timetable> IRepository<Timetable>.Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}
