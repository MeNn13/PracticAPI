using Practic.Data.Interface;
using Practic.Models;
using System.Threading.Tasks;

namespace Practic.Data.Interfaces
{
    public interface IClassroomRepository : IRepository<Classroom>
    {
        Task<Classroom> GetNumber(Classroom classroom);
    }
}
