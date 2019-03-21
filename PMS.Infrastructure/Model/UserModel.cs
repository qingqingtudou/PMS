using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Infrastructure.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Account { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public int? Sex { get; set; }

        public string TypeName { get; set; }

        public string TypeId { get; set; }

        public int? OrgId { get; set; }

        public int? RoleId { get; set; }

        public string OrgFullPath { get; set; }
    }
}
