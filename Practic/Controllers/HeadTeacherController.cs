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
        IRepository<Class> dbC;
        IRepository<Timetable> dbT;
        ApplicationContext context;

        public HeadTeacherController(ApplicationContext _context)
        {
            context = _context;
            dbU = new UserRepository(context);
            dbC = new ClassRepository(context);
            dbT = new TimetableRepository(context);
        }

        [HttpGet]
        public IActionResult Info ()
        {
            return Content("Создание пользователя('api/ht/crtUser'). Редактирование пользователя(api/ht/edtUser)");
        }

        //Запросы Создание/Редактирование/Получение/Удаление пользователей [\/]
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

            dbU.Update(user);
            await context.SaveChangesAsync();

            return Ok(user);
        }

        [Route("delUser")]
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (id != null)
            {
                dbU.Delete(id);
                await context.SaveChangesAsync();
                return Ok();
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

        //Запросы Создание/Редактирование/Удаление класса [\/]
        #region
        [Route("crtEssClass")]
        [HttpPost]
        public async Task<ActionResult<Class>> AddEssClass(Class @class)
        {
            if (@class == null)
                return BadRequest();

            if (context.classes.Any(x => x.Number == @class.Number && x.Letter == @class.Letter))
                return BadRequest(new { errorText = "Такой класс уже существует"});

            dbC.Create(new Class { Id = Guid.NewGuid().ToString(), Number = @class.Number, Letter = @class .Letter});
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

            dbC.Update(@class);
            await context.SaveChangesAsync();

            return Ok(@class);
        }

        [Route("delEssClacc")]
        [HttpPost]
        public async Task<IActionResult> DelClass(string id)
        {
            if (id != null)
            {
                dbU.Delete(id);
                await context.SaveChangesAsync();
                return Ok();
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

        //Запроса Создание/Редактирование/Удаление расписания [\/]
        #region
        [Route("crtTt")]
        [HttpPost]
        public ActionResult AddTt(Timetable timetable)
        {
            if (timetable == null)
                return BadRequest();

            if (context.timetables.Any(x => x.Id == timetable.Id))
                return BadRequest(new { errorText = "Такое расписание уже сушествует" });

            dbT.Create(new Timetable { Id = Guid.NewGuid().ToString(), Class = timetable.Class, Classroom = timetable.Classroom, Date = timetable.Date, Lesson = timetable.Lesson, Subject = timetable.Subject, User = timetable.User});
            dbT.Save();
            return Ok(timetable);
        }

        [Route("edtTt")]
        [HttpPut]
        public async Task<ActionResult<User>> PutTt(Timetable timetable)
        {
            if (timetable == null)
            {
                return BadRequest();
            }
            if (!context.users.Any(x => x.Id == timetable.Id))
            {
                return NotFound();
            }

            dbT.Update(timetable);
            await context.SaveChangesAsync();

            return Ok(timetable);
        }

        [Route("delTt")]
        [HttpPost]
        public async Task<IActionResult> DelTt(string id)
        {
            if (id != null)
            {
                dbT.Delete(id);
                await context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
        #endregion
    }
}   