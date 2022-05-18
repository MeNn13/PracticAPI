using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practic.Controllers
{
    [Route("/")]
    [ApiController]
    public class WelcomeController1 : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Добро пожаловать в API 'Электронный дневник'";
        }
    }
}
