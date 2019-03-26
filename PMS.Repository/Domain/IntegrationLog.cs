using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Repository.Domain
{
    /// <summary>
    /// 积分日志表
    /// </summary>
    public class IntegrationLog
    {
        public string Account { get; set; }

        public string Name { get; set; }

        public int OrderId { get; set; }

        public double Point { get; set; }

        public string Month { get; set; }
    }
}
