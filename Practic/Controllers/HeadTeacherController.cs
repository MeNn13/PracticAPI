using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practic.Data;
using Practic.Data.Interface;
using Practic.Data.Repository;
using Practic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practic.Controllers
{
    [Route("api/ht")]
    [Authorize(Roles = "Head teacher, Admin")]
    [ApiController]
    public class HeadTeacherController : ControllerBase
    {
        IRepository<User> dbU;
        ApplicationContext context;

        public HeadTeacherController(ApplicationContext _context)
        {
            context = _context;
            dbU = new UserRepository(context);
        }

        [HttpGet]
        public IActionResult Info ()
        {
            return Content("Создание пользователя('api/ht/crtUser'). Редактирование пользователя(api/ht/edtUser)");
        }

        //Запросы Создание/Редактирование/Получение/Удаление пользователей
        #region

        [Route("all")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return  await context.users.ToListAsync();
        }

        [Route("crtUser")]
        [HttpPost]
        public ActionResult AddUser (User user)
        {
            if (user == null)
                return BadRequest();

            if (context.users.Any(x => x.Login == user.Login))
                return BadRequest(new { errorText = "Пользователь с таким логином существует" });

            dbU.Create(new User { Id = Guid.NewGuid().ToString(), First_name = user.First_name, Midle_name = user.Midle_name, Last_name = user.Last_name, RoleId = user.RoleId, Login = user.Login, Password = "user"});
            dbU.Save();
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
            if (!context.users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            context.Update(user);
            await context.SaveChangesAsync();

            return Ok(user);
        }

        [Route("delUser")]
        [HttpPost]
        public async Task<IActionResult> Delete(User user)
        {
            if (user != null)
            {
                User us = await context.users.FirstOrDefaultAsync(p => p.Id == user.Id);
                if (us != null)
                {
                    context.users.Remove(us);
                    await context.SaveChangesAsync();
                    return Ok(us);
                }
            }
            return NotFound();
        }

        #endregion

        //Запросы Создание/Редактирование кабинета
        #region
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

        [Route("edtEssCR")]
        [HttpPut]
        public async Task<ActionResult<Classroom>> PutEssCR(Classroom classroom)
        {
            if (classroom == null)
            {
                return BadRequest();
            }
            if (!context.classrooms.Any(x => x.Id == classroom.Id))
            {
                return NotFound();
            }

            context.Update(classroom);
            await context.SaveChangesAsync();

            return Ok(classroom);
        }
        #endregion

        //Запросы Создание/Редактирование/Удаление класса
        #region
        [Route("crtEssClass")]
        [HttpPost]
        public async Task<ActionResult<Class>> AddEssClass(Class @class)
        {
            if (@class == null)
                return BadRequest();

            if (context.classes.Any(x => x.Number == @class.Number && x.Letter == @class.Letter))
                return BadRequest(new { errorText = "Такой класс уже существует"});

            context.classes.Add(new Class { Id = Guid.NewGuid().ToString(), Number = @class.Number, Letter = @class .Letter});
            await context.SaveChangesAsync();
            return Ok(@class);
        }

        [Route("edtEssClass")]
        [HttpPut]
        public async Task<ActionResult<Class>> PutEssClass(Class @class)
        {
            if (@class == null)
            {
                return BadRequest();
            }
            if (!context.classes.Any(x => x.Id == @class.Id))
            {
                return NotFound();
            }

            context.Update(@class);
            await context.SaveChangesAsync();

            return Ok(@class);
        }

        [Route("delEssClacc")]
        [HttpPost]
        public async Task<IActionResult> DelClass(Class @class)
        {
            if (@class != null)
            {
                Class cl = await context.classes.FirstOrDefaultAsync(p => p.Id == @class.Id);
                if (cl != null)
                {
                    context.classes.Remove(cl);
                    await context.SaveChangesAsync();
                    return Ok(cl);
                }
            }
            return NotFound();
        }
        #endregion

        //Запросы Создание/Редактирование/Удаление предмета
        #region
        [Route("crtEssSub")]
        [HttpPost]
        public async Task<ActionResult<Subject>> AddEssSub(Subject subject)
        {
            if (subject == null)
                return BadRequest();

            if (context.subjects.Any(x => x.Name == subject.Name))
                return BadRequest(new { errorText = "Такой класс уже существует" });

            context.subjects.Add(new Subject { Id = Guid.NewGuid().ToString(), Name = subject.Name});
            await context.SaveChangesAsync();
            return Ok(subject);
        }

        [Route("edtEssSub")]
        [HttpPut]
        public async Task<ActionResult<Subject>> PutEssSub(Subject subject)
        {
            if (subject == null)
            {
                return BadRequest();
            }
            if (!context.classes.Any(x => x.Id == subject.Id))
            {
                return NotFound();
            }

            context.Update(subject);
            await context.SaveChangesAsync();

            return Ok(subject);
        }

        [Route("delEssSub")]
        [HttpPost]
        public async Task<IActionResult> Delete(Subject sub)
        {
            if (sub != null)
            {
                Subject subject = await context.subjects.FirstOrDefaultAsync(p => p.Id == sub.Id);
                if (subject != null)
                {
                    context.subjects.Remove(subject);
                    await context.SaveChangesAsync();
                    return Ok(subject);
                }
            }
            return NotFound();
        }
        #endregion
    }
}   