using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practic.Models;
using Practic.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Controllers
{
    [Route("api/class")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet("all")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<IEnumerable<Class>> GetClasses()
        {
            var responce = await _classService.GetClasses();
            return responce.Data;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<Class> Get(string id)
        {
            var responce = await _classService.Get(id);
            return responce.Data;
        }

        [HttpPost("save")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<IActionResult> SaveClass(Class model)
        {
            if (ModelState.IsValid)
                if (model.Id == null)
                    await _classService.Create(model);
                else
                    await _classService.Update(model.Id, model);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            await _classService.Delete(id);
            return Ok("Class deleted");
        }
    }
}
