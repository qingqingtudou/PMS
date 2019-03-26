using PMS.Repository.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Repository.Domain
{
    /// <summary>
    /// 积分统计表
    /// </summary>
    public class IntegrationSum:Entity
    {
        public string MonthStr { get; set; }

        public double Sum { get; set; }

        public string Account { get; set; }
    }
}
