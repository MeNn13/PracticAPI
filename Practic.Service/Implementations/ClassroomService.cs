using Practic.Data.Interfaces;
using Practic.Domain.Enum;
using Practic.Domain.Responce;
using Practic.Models;
using Practic.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Service.Implementations
{
    public class ClassroomService : IClassroomService
    {
        private readonly IClassroomRepository _classroomRepository;

        public ClassroomService(IClassroomRepository classroomRepository)
        {
            _classroomRepository = classroomRepository;
        }

        public async Task<IBaseResponce<Classroom>> Create(Classroom classroom)
        {
            var baseResponce = new BaseResponce<Classroom>();

            try
            {
                var classroomNum = await _classroomRepository.GetNumber(classroom);

                if (classroomNum == null)
                {
                    var cr = new Classroom()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Number = classroom.Number,
                    };

                    await _classroomRepository.Create(cr);
                }

                baseResponce.Description = "The class exists";
                baseResponce.StatusCode = StatusCode.Exists;
            }
            catch(Exception ex)
            {
                return new BaseResponce<Classroom>()
                {
                    Description = $"[CreateClassroom] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            return baseResponce;
        }

        public async Task<IBaseResponce<bool>> Delete(string id)
        {
            var baseResponce = new BaseResponce<bool>();

            try
            {
                var classroom = await _classroomRepository.Get(id);

                if (classroom == null)
                {
                    baseResponce.Description = "Classroom not found";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                await _classroomRepository.Delete(classroom);

                return baseResponce;
            }
            catch (Exception ex)
            {
                return new BaseResponce<bool>()
                {
                    Description = $"[DeleteClassroom] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<Classroom>> Get(string id)
        {
            var baseResponce = new BaseResponce<Classroom>();

            try
            {
                var classroom = await _classroomRepository.Get(id);

                if (classroom == null)
                {
                    baseResponce.Description = "Classroom not found";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                baseResponce.Data = classroom;
                return baseResponce;
            }
            catch (Exception ex)
            {
                return new BaseResponce<Classroom>()
                {
                    Description = $"[GetClassroom] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<IEnumerable<Classroom>>> GetClasses()
        {
            var baseResponce = new BaseResponce<IEnumerable<Classroom>>();

            try
            {
                var classrooms = await _classroomRepository.GetAll();

                if (classrooms.Count == 0)
                {
                    baseResponce.Description = "Найдено 0 элементов";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                baseResponce.Data = classrooms;
                baseResponce.StatusCode = StatusCode.OK;

                return baseResponce;
            }
            catch (Exception ex)
            {
                return new BaseResponce<IEnumerable<Classroom>>()
                {
                    Description = $"[GetClassrooms] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<Classroom>> Update(string id, Classroom classroom)
        {
            var baseResponce = new BaseResponce<Classroom>();

            try
            {
                var cls = await _classroomRepository.Get(id);
                if (cls == null)
                {
                    baseResponce.Description = "Classroom not found";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                cls.Number = classroom.Number;

                await _classroomRepository.Update(cls);

                return baseResponce;
            }
            catch (Exception ex)
            {
                return new BaseResponce<Classroom>()
                {
                    Description = $"[UpdateClassroom] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
