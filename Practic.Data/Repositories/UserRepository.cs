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

        public bool Create(User item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public User Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            return _context.users.ToListAsync();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
