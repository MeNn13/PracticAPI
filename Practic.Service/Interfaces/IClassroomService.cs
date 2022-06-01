using Practic.Domain.Responce;
using Practic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Service.Interfaces
{
    public interface IClassroomService
    {
        Task<IBaseResponce<IEnumerable<Classroom>>> GetClasses();
        Task<IBaseResponce<Classroom>> Get(string id);
        Task<IBaseResponce<Classroom>> Create(Classroom classroom);
        Task<IBaseResponce<bool>> Delete(string id);
        Task<IBaseResponce<Classroom>> Update(string id, Classroom classroom);
    }
}
