 using Microsoft.EntityFrameworkCore;
using Practic.Data.Interface;
using Practic.Data.Interfaces;
using Practic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            User user = await _context.users.FirstOrDefaultAsync(x => x.Login == item.Login);

            if (user != null)
                return false;

            await _context.AddAsync(new User { Id = Guid.NewGuid().ToString(), First_name = item.First_name, Midle_name = item.Midle_name, Last_name = item.Last_name, Login = item.Login, Password = item.Password, RoleId = item.RoleId});
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(User item)
        {
            //User user = _context.users.FirstOrDefault(x => x.Id == item.Id);
            //if (user == null)
            //    return false;

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

        public void Update(User item)
        {
            throw new NotImplementedException();
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
