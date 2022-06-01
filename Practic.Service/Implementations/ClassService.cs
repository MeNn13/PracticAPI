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
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<IBaseResponce<Class>> Create(Class @class)
        {
            var baseResponce = new BaseResponce<Class>();

            try
            {
                var classId = await _classRepository.GetClass(@class);

                if (classId == null)
                {
                    var cls = new Class()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Number = @class.Number,
                        Letter = @class.Letter
                    };

                    await _classRepository.Create(cls);
                }

                baseResponce.Description = "The class exists";
                baseResponce.StatusCode = StatusCode.Exists;
            }
            catch (Exception ex)
            {
                return new BaseResponce<Class>()
                {
                    Description = $"[CreateClass] : {ex.Message}",
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
                var @class = await _classRepository.Get(id);

                if (@class == null)
                {
                    baseResponce.Description = "Class not found";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                await _classRepository.Delete(@class);

                return baseResponce;
            }
            catch (Exception ex)
            {
                return new BaseResponce<bool>()
                {
                    Description = $"[DeleteClass] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<Class>> Get(string id)
        {
            var baseResponce = new BaseResponce<Class>();

            try
            {
                var @class = await _classRepository.Get(id);

                if (@class == null)
                {
                    baseResponce.Description = "Class not found";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                baseResponce.Data = @class;
                return baseResponce;
            }
            catch (Exception ex)
            {
                return new BaseResponce<Class>()
                {
                    Description = $"[GetClass] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<IEnumerable<Class>>> GetClasses()
        {
            var baseResponce = new BaseResponce<IEnumerable<Class>>();

            try
            {
                var classes = await _classRepository.GetAll();

                if (classes.Count == 0)
                {
                    baseResponce.Description = "Найдено 0 элементов";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                baseResponce.Data = classes;
                baseResponce.StatusCode = StatusCode.OK;

                return baseResponce;
            }
            catch (Exception ex)
            {
                return new BaseResponce<IEnumerable<Class>>()
                {
                    Description = $"[GetClasses] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<Class>> Update(string id, Class model)
        {
            var baseResponce = new BaseResponce<Class>();

            try
            {
                var cls = await _classRepository.Get(id);
                if (cls == null)
                {
                    baseResponce.Description = "Class not found";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                cls.Letter = model.Letter;
                cls.Number = model.Number;

                await _classRepository.Update(cls);

                return baseResponce;
            }
            catch (Exception ex)
            {
                return new BaseResponce<Class>()
                {
                    Description = $"[UpdateClass] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
