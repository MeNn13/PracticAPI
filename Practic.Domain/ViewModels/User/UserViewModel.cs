using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic.Domain.ViewModels.User
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string First_name { get; set; }
        public string Midle_name { get; set; }
        public string Last_name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public int? RoleId { get; set; }
    }
}
