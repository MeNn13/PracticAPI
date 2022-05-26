using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practic.Data;

namespace Practic.Controllers
{
    [Route("api/teach")]
    [Authorize(Roles = "Head teacher, Admin, Teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        ApplicationContext context;
        public TeacherController(ApplicationContext _context)
        {
            context = _context;
        }
    }
}
