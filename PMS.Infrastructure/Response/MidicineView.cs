using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Infrastructure.Response
{
    public class MidicineView
    {
        public int Id { get; set; }

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

        /// <summary>
        /// 库存
        /// </summary>
        public int InventoryNum { get; set; }
    }
}
