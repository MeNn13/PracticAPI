using Practic.Domain.Responce;
using Practic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Service.Interfaces
{
    public interface ISubjectService
    {
        Task<IBaseResponce<IEnumerable<Subject>>> GetSubjects();
        Task<IBaseResponce<Subject>> Get(string id);
        Task<IBaseResponce<Subject>> Create(Subject subject);
        Task<IBaseResponce<bool>> Delete(string id);
        Task<IBaseResponce<Subject>> Update(string id, Subject subject);
    }
}
