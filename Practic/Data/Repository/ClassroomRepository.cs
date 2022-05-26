using Microsoft.AspNetCore.Mvc;
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
        private ApplicationContext _context;

        public ClassroomRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Classroom item)
        {
            _context.classrooms.Add(item);
        }

        public void Delete(string id)
        {
            Classroom classroom = _context.classrooms.Find(id);
            if (classroom != null)
                _context.classrooms.Remove(classroom);
        }

        public Classroom Get(string id)
        {
            return _context.classrooms.Find(id);
        }

        public async Task<ActionResult<IEnumerable<Classroom>>> GetAll()
        {
            return await _context.classrooms.ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Classroom item)
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
