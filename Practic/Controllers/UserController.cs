using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practic.Data.Interfaces;
using Practic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("all")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<List<User>> GetUsers()
        {
            return await _userRepository.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<User> Get (string id)
        {
            return await _userRepository.Get(id);
        }

        [HttpPost("crt")]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<IActionResult> Create (User user)
        {
            if (await _userRepository.Create(user))
                return Ok("User added");
            return BadRequest("The login exists");
        }

        [HttpDelete]
        [Authorize(Roles = "Head teacher, Admin")]
        public async Task<IActionResult> Delete(User user)
        {
            if(await _userRepository.Delete(user))
                return Ok("User deleted");
            return BadRequest("There is no such user");
        }
    }
}
