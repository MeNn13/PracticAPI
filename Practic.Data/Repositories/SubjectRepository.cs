using Microsoft.EntityFrameworkCore;
using Practic.Data.Interfaces;
using Practic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Data.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Subject item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Subject item)
        {
            _context.subjects.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Subject> Get(string id)
        {
            return await _context.subjects.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Subject>> GetAll()
        {
            return _context.subjects.ToListAsync();
        }

        public async Task<Subject> Update(Subject item)
        {
            _context.subjects.Update(item);
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

        public async Task<Subject> GetName(string subject)
        {
            return await _context.subjects.FirstOrDefaultAsync(s => s.Name == subject);
        }
    }
}
