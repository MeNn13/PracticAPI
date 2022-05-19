using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practic.Controllers
{
    [Route("api/ht")]
    [Authorize(Roles = "Завуч, Администратор")]
    [ApiController]
    public class HeadTeacherController : ControllerBase
    {
        ApplicationContext context;
        public HeadTeacherController(ApplicationContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult Info ()
        {
            return Content("Создание пользователя('api/ht/crtUser'). Редактирование пользователя(api/ht/edtUser)");
        }

        //Запросы Создание/Редактирование/Получение пользователей
        #region

        [Route("all")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return  await context.Users.ToListAsync();
        }

        [Route("crtUser")]
        [HttpPost]
        public async Task<ActionResult<User>> AddUser (User user)
        {
            if (user == null)
                return BadRequest();

            if (context.Users.Any(x => x.Login == user.Login))
                return BadRequest(new { errorText = "Пользователь с таким логином существует" });

            context.Users.Add(new User { Id = Guid.NewGuid().ToString(), First_name = user.First_name, Midle_name = user.Midle_name, Last_name = user.Last_name, Role = user.Role, Login = user.Login, Password = "user"});
            await context.SaveChangesAsync();
            return Ok(user);
        }

        [Route("edtUser")]
        [HttpPut]
        public async Task<ActionResult<User>> PutUser (User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!context.Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            context.Update(user);
            await context.SaveChangesAsync();

            return Ok(user);
        }

        #endregion

        [Route("crtEssCR")]
        [HttpPost]
        public async Task<ActionResult<Classroom>> AddEssCR (Classroom classroom)
        {
            if (classroom == null)
                return BadRequest();

            if (context.classrooms.Any(x => x.Number == classroom.Number))
                return BadRequest(new { errorText = "Кабинет с таким номером существует" });

            context.classrooms.Add(new Classroom { Id = Guid.NewGuid().ToString(), Number = classroom.Number});
            await context.SaveChangesAsync();
            return Ok(classroom);
        }
    }
}