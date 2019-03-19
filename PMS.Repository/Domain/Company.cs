using PMS.Repository.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMS.Repository.Domain
{
    /// <summary>
    /// 公司表
    /// </summary>
    [Table("Company")]
    public partial class Company: StandardEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
