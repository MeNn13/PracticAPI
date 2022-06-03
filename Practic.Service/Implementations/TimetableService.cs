using Practic.Data.Interfaces;
using Practic.Domain.Enum;
using Practic.Domain.Responce;
using Practic.Domain.ViewModels;
using Practic.Models;
using Practic.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Service.Implementations
{
    public class TimetableService : ITimetableService
    {
        private readonly ITimetableRepository _timetableRepository;

        public TimetableService(ITimetableRepository timetableRepository)
        {
            _timetableRepository = timetableRepository;
        }

        public async Task<IBaseResponce<Timetable>> Create(TimetableViewModel model)
        {
            var baseResponce = new BaseResponce<Timetable>();

            try
            {
                var timetable = await _timetableRepository.GetDate(model);

                DateTime dateTimeFirst = model.Date;
                DateTime dateTimeLast = model.Date;

                if (timetable == null)
                {
                    switch(model.Lesson)
                    {
                        case 1:
                            dateTimeFirst = dateTimeFirst.AddHours(8);
                            dateTimeLast = dateTimeLast.AddHours(8).AddMinutes(45);
                            break;

                        case 2:
                            dateTimeFirst = dateTimeFirst.AddHours(8).AddMinutes(50);
                            dateTimeLast = dateTimeLast.AddHours(9).AddMinutes(35);
                            break;

                        case 3:
                            dateTimeFirst = dateTimeFirst.AddHours(9).AddMinutes(40);
                            dateTimeLast = dateTimeLast.AddHours(10).AddMinutes(25);
                            break;

                        case 4:
                            dateTimeFirst = dateTimeFirst.AddHours(10).AddMinutes(30);
                            dateTimeLast = dateTimeLast.AddHours(11).AddMinutes(15);
                            break;

                        case 5:
                            dateTimeFirst = dateTimeFirst.AddHours(11).AddMinutes(20);
                            dateTimeLast = dateTimeLast.AddHours(12).AddMinutes(5);
                            break;

                        case 6:
                            dateTimeFirst = dateTimeFirst.AddHours(12).AddMinutes(20);
                            dateTimeLast = dateTimeLast.AddHours(13).AddMinutes(5);
                            break;

                        case 7:
                            dateTimeFirst = dateTimeFirst.AddHours(13).AddMinutes(10);
                            dateTimeLast = dateTimeLast.AddHours(13).AddMinutes(55);
                            break;

                        case 8:
                            dateTimeFirst = dateTimeFirst.AddHours(14);
                            dateTimeLast = dateTimeLast.AddHours(14).AddMinutes(45);
                            break;

                        case 9:
                            dateTimeFirst = dateTimeFirst.AddHours(14).AddMinutes(50);
                            dateTimeLast = dateTimeLast.AddHours(15).AddMinutes(35);
                            break;

                        case 10:
                            dateTimeFirst = dateTimeFirst.AddHours(15).AddMinutes(40);
                            dateTimeLast = dateTimeLast.AddHours(16).AddMinutes(25);
                            break;
                    }

                    var tt = new Timetable()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Lesson = model.Lesson,
                        Date_First = dateTimeFirst,
                        Date_Last = dateTimeLast,
                        Date = dateTimeFirst.ToShortDateString(),
                        Subject = model.Subject,
                        User = model.User,
                        Class = model.Class.Number.ToString() + model.Class.Letter,
                        Classroom = model.Classroom
                    };

                    await _timetableRepository.Create(tt);
                }

                baseResponce.Description = "The timetable exists";
                baseResponce.StatusCode = StatusCode.Exists;
            }
            catch (Exception ex)
            {
                return new BaseResponce<Timetable>()
                {
                    Description = $"[CreateTimetable] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            baseResponce.StatusCode = StatusCode.OK;
            return baseResponce;
        }

        public async Task<IBaseResponce<bool>> Delete(string id)
        {
            var baseResponce = new BaseResponce<bool>();

            try
            {
                var timetable = await _timetableRepository.Get(id);

                if (timetable == null)
                {
                    baseResponce.Description = "Timetable not found";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                await _timetableRepository.Delete(timetable);

                baseResponce.StatusCode = StatusCode.OK;
                return baseResponce;
            }
            catch (Exception ex)
            {
                return new BaseResponce<bool>()
                {
                    Description = $"[DeleteTimetable] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<Timetable>> Get(string id)
        {
            var baseResponce = new BaseResponce<Timetable>();

            try
            {
                var timetable = await _timetableRepository.Get(id);

                if (timetable == null)
                {
                    baseResponce.Description = "Timetable not found";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                baseResponce.Data = timetable;
                baseResponce.StatusCode = StatusCode.OK;
                return baseResponce;
            }
            catch (Exception ex)
            {
                return new BaseResponce<Timetable>()
                {
                    Description = $"[GetTimetable] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<Timetable>> GetTimetableClass(ClassViewModel @class)
        {
            var baseResponce = new BaseResponce<Timetable>();

            try
            {
                var timetable = await _timetableRepository.GetTimetableClass(@class);

                if (timetable == null)
                {
                    baseResponce.Description = "Timetable not found";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                baseResponce.Data = timetable;
                baseResponce.StatusCode = StatusCode.OK;

                return baseResponce;
            }
            catch(Exception ex)
            {
                return new BaseResponce<Timetable>()
                {
                    Description = $"[GetTimetableClass] : {ex.Message}",
                    StatusCode= StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<IEnumerable<Timetable>>> GetTimetables()
        {
            var baseResponce = new BaseResponce<IEnumerable<Timetable>>();

            try
            {
                var timetable = await _timetableRepository.GetAll();

                if (timetable.Count == 0)
                {
                    baseResponce.Description = "Найдено 0 элементов";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                baseResponce.Data = timetable;
                baseResponce.StatusCode = StatusCode.OK;

                return baseResponce;
            }
            catch (Exception ex)
            {
                return new BaseResponce<IEnumerable<Timetable>>()
                {
                    Description = $"[GetTimetable] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<Timetable>> Update(string id, TimetableViewModel model)
        {
            var baseResponce = new BaseResponce<Timetable>();

            try
            {
                var timetable = await _timetableRepository.Get(id);

                if (timetable == null)
                {
                    baseResponce.Description = "Timetable not found";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                timetable.Subject = model.Subject;
                timetable.User = model.User;
                timetable.Class = model.Class.Number.ToString() + model.Class.Letter;
                timetable.Classroom = model.Classroom;

                await _timetableRepository.Update(timetable);

                baseResponce.StatusCode = StatusCode.OK;
                return baseResponce;
            }
            catch (Exception ex)
            {
                return new BaseResponce<Timetable>()
                {
                    Description = $"[UpdateTimetables] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
