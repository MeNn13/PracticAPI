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

        public async Task<bool> Create(Class item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Class item)
        {
            _context.classes.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Class> Get(string id)
        {
            return await _context.classes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Class>> GetAll()
        {
            return _context.classes.ToListAsync();
        }

        public async Task<Class> Update(Class item)
        {
            _context.classes.Update(item);
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
