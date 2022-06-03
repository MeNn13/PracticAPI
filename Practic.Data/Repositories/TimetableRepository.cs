using Microsoft.EntityFrameworkCore;
using Practic.Data.Interfaces;
using Practic.Domain.ViewModels;
using Practic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Data.Repository
{
    public class TimetableRepository : ITimetableRepository
    {
        private ApplicationDbContext _context;

        public TimetableRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Timetable item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Timetable item)
        {
            _context.timetables.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Timetable> Get(string id)
        {
            return await _context.timetables.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Timetable>> GetAll()
        {
            return _context.timetables.ToListAsync();
        }

        public async Task<Timetable> Update(Timetable item)
        {
            _context.timetables.Update(item);
            await _context.SaveChangesAsync();
            return item;
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

        public async Task<Timetable> GetDate(TimetableViewModel model)
        {
            string dateM = model.Date.ToShortDateString();

            return await _context.timetables.FirstOrDefaultAsync(t => t.Date == dateM && t.Lesson == model.Lesson);
        }

        public async Task<Timetable> GetTimetableClass(ClassViewModel @class)
        {
            return await _context.timetables.FirstOrDefaultAsync(t => t.Class == @class.Number.ToString() + @class.Letter);
        }
    }
}
