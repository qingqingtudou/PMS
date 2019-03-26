using PMS.Repository.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMS.Repository.Domain
{
    /// <summary>
    /// 库存
    /// </summary>
    [Table("Inventory")]
    public partial class Inventory: StandardEntity
    {
        public int Total { get; set; }

        /// <summary>
        /// 药品id
        /// </summary>
        public int MID { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        public int? Batch { get; set; }

        [ForeignKey("MedicineForeignKey")]
        public Medicine Medicine { get; set; }
    }
}
