using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Infrastructure.ViewModel
{
    public class LoginResult
    {
        public int Id { get; set; }

        public string Account { get; set; }
        public string Name { get; set; }

        public string Token { get; set; }
    }
}
