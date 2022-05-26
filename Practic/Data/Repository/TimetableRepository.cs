using Microsoft.AspNetCore.Mvc;
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
        private ApplicationContext _context;

        public TimetableRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Timetable item)
        {
            _context.timetables.Add(item);
        }

        public void Delete(string id)
        {
            Timetable timetable = _context.timetables.Find(id);
            if (timetable != null)
                _context.timetables.Remove(timetable);
        }

        public Timetable Get(string id)
        {
            return _context.timetables.Find(id);
        }

        public async Task<ActionResult<IEnumerable<Timetable>>> GetAll()
        {
            return await _context.timetables.ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Timetable item)
        {
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
