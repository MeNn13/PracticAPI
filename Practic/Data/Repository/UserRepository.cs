using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practic.Data.Interface;
using Practic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Data.Repository
{
    public class UserRepository : IRepository<User>
    {
        private ApplicationContext _context;

        public UserRepository (ApplicationContext context)
        {
            _context = context;
        }

        public void Create(User item)
        {
            _context.users.Add(item);
        }

        public void Delete(string id)
        {
            User user = _context.users.Find(id);
            if (user != null)
                _context.users.Remove(user);
        }

        public User Get(string id)
        {
            return _context.users.Find(id);
        }

        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await _context.users.ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(User item)
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
