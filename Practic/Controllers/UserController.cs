using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practic.Domain.ViewModels.User;
using Practic.Models;
using Practic.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("all")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            var responce = await _userService.GetUsers();
            return responce.Data;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<User> Get(string id)
        {
            var responce = await _userService.Get(id);
            return responce.Data;
        }

        [HttpPost("save")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<IActionResult> SaveUser(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
                if (userViewModel.Id == null)
                    await _userService.Create(userViewModel);
                else
                    await _userService.Update(userViewModel.Id, userViewModel);

            return Ok();    
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.Delete(id);

            return Ok("User deleted");
        }
    }
}
