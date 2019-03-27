using PMS.Repository.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMS.Repository.Domain
{
    /// <summary>
    /// 药品采购中间表
    /// </summary>
    [Table("MedicineSupplier")]
    public class MedicineSupplier : Entity
    {
        public int MId { get; set; }
        public Medicine Medicine { get; set; }
        public int CId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
