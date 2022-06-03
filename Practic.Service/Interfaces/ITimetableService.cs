using Practic.Domain.Responce;
using Practic.Domain.ViewModels;
using Practic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Service.Interfaces
{
    public interface ITimetableService
    {
        Task<IBaseResponce<IEnumerable<Timetable>>> GetTimetables();
        Task<IBaseResponce<Timetable>> Get(string id);
        Task<IBaseResponce<Timetable>> Create(TimetableViewModel model);
        Task<IBaseResponce<bool>> Delete(string id);
        Task<IBaseResponce<Timetable>> Update(string id, TimetableViewModel model);
        Task<IBaseResponce<Timetable>> GetTimetableClass(ClassViewModel @class);
    }
}