using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practic.Models;

namespace Practic.Controllers
{
    [Route("api/teach")]
    [Authorize(Roles = "Завуч, Администратор, Учитель")]
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
