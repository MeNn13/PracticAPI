using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practic.Controllers
{
    [Route("/")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Добро пожаловать в API 'Электронный дневник'";
        }
    }
}
