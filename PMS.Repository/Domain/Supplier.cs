using PMS.Repository.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMS.Repository.Domain
{
    /// <summary>
    /// 供应商表
    /// </summary>
    [Table("Supplier")]
    public partial class Supplier: StandardEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }
        public int MId { get; set; }

        public Medicine Medicine { get; set; }

        public List<MedicineSupplier> MedicineSuppliers { get; set; }
    }
}
