using PMS.Repository.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Repository.Domain
{
    [Table("SysUser")]
    public partial class SysUser: StandardEntity
    {
        public string Account { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public int Sex { get; set; }

        public string TypeName { get; set; }

        public string TypeId { get; set; }

        public int OrgId { get; set; }

        public int RoleId { get; set; }
    }
}
