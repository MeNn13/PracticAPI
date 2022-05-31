using Practic.Data.Interface;
using Practic.Models;
using System.Threading.Tasks;

namespace Practic.Data.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetLogin(string login);
    }
}
