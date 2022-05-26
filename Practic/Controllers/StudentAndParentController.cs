using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practic.Data;

namespace Practic.Controllers
{
    [Route("api/ht")]
    [Authorize(Roles = "Admin, Student, Parent")]
    [ApiController]
    public class StudentAndParentController : ControllerBase
    {
        ApplicationContext context;
        public StudentAndParentController (ApplicationContext _context)
        {
            context = _context;
        }
    }
}
