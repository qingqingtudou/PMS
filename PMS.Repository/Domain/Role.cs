using PMS.Repository.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMS.Repository.Domain
{
    [Table("Role")]
    public partial class Role: StandardEntity
    {
        public string Name { get; set; }

        public int Sort { get; set; }

        public List<RoleModule> RoleModules { get; set; }
    }
}
