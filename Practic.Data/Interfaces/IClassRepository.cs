using Practic.Data.Interface;
using Practic.Models;
using System.Threading.Tasks;

namespace Practic.Data.Interfaces
{
    public interface IClassRepository : IRepository<Class>
    {
        Task<Class> GetClass(Class @class);
    }
}
