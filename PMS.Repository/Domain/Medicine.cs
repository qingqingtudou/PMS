using PMS.Repository.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMS.Repository.Domain
{
    /// <summary>
    /// 药品实体类
    /// </summary>
    [Table("Medicine")]
    public partial class Medicine:StandardEntity
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime DateinProduced { get; set; }

        /// <summary>
        /// 保质期
        /// </summary>
        public string ExpirationDate { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        public Inventory Inventory { get; set; }
    }
}
