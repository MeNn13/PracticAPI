using Practic.Data.Interface;
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
        private readonly IRepository<Class> _repository;

        public ClassService(IRepository<Class> repository)
        {
            _repository = repository;
        }

        public async Task<IBaseResponce<Class>> Create(Class @class)
        {
            var baseResponce = new BaseResponce<Class>();

            try
            {
                var classId = await _repository.Get(@class.Id);

                if (classId == null)
                {
                    var cls = new Class()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Number = @class.Number,
                        Letter = @class.Letter
                    };

                    await _repository.Create(cls);
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
                var @class = await _repository.Get(id);

                if (@class == null)
                {
                    baseResponce.Description = "Class not found";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                await _repository.Delete(@class);

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

        public Task<IBaseResponce<Class>> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponce<IEnumerable<Class>>> GetClasses()
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponce<Class>> Update(string id, Class @class)
        {
            throw new NotImplementedException();
        }
    }
}
