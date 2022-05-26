using Microsoft.AspNetCore.Mvc;
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
        private ApplicationContext _context;

        public ClassRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Class item)
        {
            _context.classes.Add(item);
        }

        public void Delete(string id)
        {
            Class @class = _context.classes.Find(id);
            if (@class != null)
                _context.classes.Remove(@class);
        }

        public Class Get(string id)
        {
            return _context.classes.Find(id);
        }

        public async Task<ActionResult<IEnumerable<Class>>> GetAll()
        {
            return await _context.classes.ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Class item)
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
