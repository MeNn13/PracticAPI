using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practic.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practic.Controllers
{
    [Route("api/admin")]
    [Authorize(Roles = "Администратор")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        ApplicationContext context;
        public AdminController(ApplicationContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }

    }
}
