using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practic.Models;
using Practic.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Controllers
{
    [Route("api/classroom")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomService _classroomService;

        public ClassroomController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }

        [HttpGet("all")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<IEnumerable<Classroom>> GetClassrooms ()
        {
            var responce = await _classroomService.GetClasses();
            return responce.Data;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<Classroom> Get (string id)
        {
            var responce = await _classroomService.Get(id);
            return responce.Data;
        }

        [HttpPost("save")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<IActionResult> SaveClassroom(Classroom classroom)
        {
            if (ModelState.IsValid)
                if (classroom.Id == null)
                    await _classroomService.Create(classroom);
                else
                    await _classroomService.Update(classroom.Id, classroom);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            await _classroomService.Delete(id);
            return Ok("Classroom deleted");
        }
    }
}
