using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practic.Domain.ViewModels;
using Practic.Models;
using Practic.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Controllers
{
    [Route("api/timetable")]
    [ApiController]
    public class TimetableController : ControllerBase
    {
        private readonly ITimetableService _timetableService;

        public TimetableController(ITimetableService timetableService)
        {
            _timetableService = timetableService;
        }

        [HttpGet("all")]
        [Authorize(Roles = "Head teacher, Admin, Teacher, Student, Parent")]
        public async Task<IEnumerable<Timetable>> GetTimetables()
        {
            var responce = await _timetableService.GetTimetables();
            return responce.Data;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Head teacher, Admin, Teacher, Student, Parent")]
        public async Task<Timetable> Get(string id)
        {
            var responce = await _timetableService.Get(id);
            return responce.Data;
        }

        [HttpPost("save")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<IActionResult> SaveTimetable(TimetableViewModel model)
        {
            if (ModelState.IsValid)
                if (model.Id == null)
                    await _timetableService.Create(model);
                else
                    await _timetableService.Update(model.Id, model);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<IActionResult> Delete (string id)
        {
            await _timetableService.Delete(id);
            return Ok("Timetable deleted");
        }
    }
}
