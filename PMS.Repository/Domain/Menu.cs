using PMS.Repository.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMS.Repository.Domain
{
    [Table("menu")]
    public partial class Menu: StandardEntity
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string IconName { get; set; }

        public int Sort { get; set; }

        public int Pid { get; set; }
    }
}
