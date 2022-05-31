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

        public async Task<bool> Create(Classroom item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Classroom item)
        {
            _context.classrooms.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Classroom> Get(string id)
        {
            return await _context.classrooms.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Classroom>> GetAll()
        {
            return _context.classrooms.ToListAsync();
        }

        public async Task<Classroom> Update(Classroom item)
        {
            _context.classrooms.Update(item);
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
    }
}
