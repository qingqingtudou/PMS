using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Infrastructure.ViewModel
{
    public class LoginModel
    {
        public string Account { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
