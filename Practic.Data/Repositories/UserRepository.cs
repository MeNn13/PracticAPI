 using Microsoft.EntityFrameworkCore;
using Practic.Data.Interfaces;
using Practic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(User item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(User item)
        {
            _context.users.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> Get(string id)
        {
            return await _context.users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<User>> GetAll()
        {
            return _context.users.ToListAsync();
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

        public async Task<User> Update(User item)
        {
            _context.users.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<User> GetLogin(string login)
        {
            return await _context.users.FirstOrDefaultAsync(x => x.Login == login);
        }
    }
}
