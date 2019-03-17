using PMS.Repository.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMS.Repository.Domain
{
    [Table("Org")]
    public partial class Org: TreeEntity
    {
        public string OrgName { get; set; }
        public int Pid { get; set; }
        public int Sort { get; set; }
        public string TypeName { get; set; }
        public string TypeId { get; set; }
    }
}
