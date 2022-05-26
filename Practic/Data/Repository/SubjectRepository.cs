using Microsoft.AspNetCore.Mvc;
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
        private ApplicationContext _context;

        public SubjectRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Subject item)
        {
            _context.subjects.Add(item);
        }

        public void Delete(string id)
        {
            Subject subject = _context.subjects.Find(id);
            if (subject != null)
                _context.subjects.Remove(subject);
        }

        public Subject Get(string id)
        {
            return _context.subjects.Find(id);
        }

        public async Task<ActionResult<IEnumerable<Subject>>> GetAll()
        {
            return await _context.subjects.ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Subject item)
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
