using PMS.Repository.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMS.Repository.Domain
{
    [Table("RoleModule")]
    public class RoleModule : Entity
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int ModuleId{ get; set; }

        public Module Module { get; set; }
    }
}
