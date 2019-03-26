using PMS.Repository.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Repository.Domain
{
    /// <summary>
    /// 订单  包括供应商订单、顾客订单
    /// </summary>
    public class Order: StandardEntity
    {
        /// <summary>
        /// 单价
        /// </summary>
        public double UnitPrice { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 买家
        /// </summary>
        public string Buyer { get; set; }

        public int? BuyerAccount { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        public double Discount { get; set; }

        public double TotalPrice { get; set; }

        /// <summary>
        /// 销售员
        /// </summary>
        public string Seller { get; set; }

        /// <summary>
        /// 结算员
        /// </summary>
        public string Checkouter { get; set; }

        /// <summary>
        /// 结算方式
        /// </summary>
        public string ClearingForm { get; set; }
    }
}
