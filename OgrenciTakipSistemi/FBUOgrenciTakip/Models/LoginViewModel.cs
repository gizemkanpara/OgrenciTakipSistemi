using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBUOgrenciTakip.Models
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string RedirectController { get; set; }
        public string RedirectAction { get; set; }
    }
}
