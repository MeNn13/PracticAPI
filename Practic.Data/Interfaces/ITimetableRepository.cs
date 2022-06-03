using Practic.Data.Interface;
using Practic.Domain.ViewModels;
using Practic.Models;
using System;
using System.Threading.Tasks;

namespace Practic.Data.Interfaces
{
    public interface ITimetableRepository : IRepository<Timetable>
    {
        Task<Timetable> GetDate(TimetableViewModel model);
        Task<Timetable> GetTimetableClass(ClassViewModel @class);
    }
}
