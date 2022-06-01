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
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<IBaseResponce<Subject>> Create(Subject subject)
        {
            var baseResponce = new BaseResponce<Subject>();

            try
            {
                var sub = await _subjectRepository.GetName(subject.Name);

                if (sub == null)
                {
                    var subj = new Subject()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = subject.Name
                    };

                    await _subjectRepository.Create(subj);
                }

                baseResponce.Description = "The subject exists";
                baseResponce.StatusCode = StatusCode.Exists;
            }
            catch (Exception ex)
            {
                return new BaseResponce<Subject>()
                {
                    Description = $"[CreateSubject] : {ex.Message}",
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
                var subject = await _subjectRepository.Get(id);

                if (subject == null)
                {
                    baseResponce.Description = "Subject not found";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                await _subjectRepository.Delete(subject);
                return baseResponce;
            }
            catch (Exception ex)
            {
                return new BaseResponce<bool>()
                {
                    Description = $"[DeleteSubject] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<Subject>> Get(string id)
        {
            var baseResponce = new BaseResponce<Subject>();

            try
            {
                var subject = await _subjectRepository.Get(id);

                if (subject == null)
                {
                    baseResponce.Description = "Subject not found";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                baseResponce.Data = subject;
                return baseResponce;
            }
            catch (Exception ex)
            {
                return new BaseResponce<Subject>()
                {
                    Description = $"[GetSubject] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<IEnumerable<Subject>>> GetSubjects()
        {
            var baseResponce = new BaseResponce<IEnumerable<Subject>>();

            try
            {
                var subject = await _subjectRepository.GetAll();

                if (subject == null)
                {
                    baseResponce.Description = "Найдено 0 элементов";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                baseResponce.Data = subject;
                baseResponce.StatusCode = StatusCode.OK;
                return baseResponce;
            }
            catch (Exception ex)
            {
                return new BaseResponce<IEnumerable<Subject>>()
                {
                    Description = $"[GetSubjects] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<Subject>> Update(string id, Subject subject)
        {
            var baseResponce = new BaseResponce<Subject>();

            try
            {
                var sub = await _subjectRepository.Get(id);
                
                if (sub == null)
                {
                    baseResponce.Description = "Subject not found";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                sub.Name = subject.Name;

                await _subjectRepository.Update(sub);

                return baseResponce;
            }
            catch (Exception ex)
            {
                return new BaseResponce<Subject>()
                { 
                    Description = $"[UpdateSubject] : {ex.Message}",
                    StatusCode= StatusCode.InternalServerError
                };
            }
        }
    }
}
