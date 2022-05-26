using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practic.Data;
using Practic.Models;
using System.Collections.Generic;
using System.Linq;

namespace Practic.Controllers
{
    [Route("/")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        ApplicationContext context;

        public WelcomeController (ApplicationContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public string Get()
        {
            return "Добро пожаловать в API 'Электронный дневник'";
        }
    }
}
