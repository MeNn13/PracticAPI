using Practic.Domain.Responce;
using Practic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Service.Interfaces
{
    public interface IClassService
    {
        Task<IBaseResponce<IEnumerable<Class>>> GetClasses();
        Task<IBaseResponce<Class>> Get(string id);
        Task<IBaseResponce<Class>> Create(Class @class);
        Task<IBaseResponce<bool>> Delete(string id);
        Task<IBaseResponce<Class>> Update(string id, Class @class);
    }
}
