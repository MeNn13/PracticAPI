using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practic.Models;
using Practic.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Controllers
{
    [Route("api/subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet("all")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            var responce = await _subjectService.GetSubjects();
            return responce.Data;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<Subject> Get(string id)
        {
            var responce = await _subjectService.Get(id);
            return responce.Data;
        }

        [HttpPost("save")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<IActionResult> SaveSubject(Subject subject)
        {
            if (ModelState.IsValid)
                if (subject.Id == null)
                    await _subjectService.Create(subject);
                else
                    await _subjectService.Update(subject.Id, subject);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<IActionResult> Delete (string id)
        {
            await _subjectService.Delete(id);
            return Ok("Subject deleted");
        }
    }
}
