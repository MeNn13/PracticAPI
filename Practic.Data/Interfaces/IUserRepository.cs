using Practic.Data.Interface;
using Practic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic.Data.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User item);
    }
}
