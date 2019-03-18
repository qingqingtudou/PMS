using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Repository.Core
{
    /// <summary>
    /// 标准模型基类   数据假删，包括创建人、创建时间、更新人、更新时间
    /// </summary>
    public abstract class StandardEntity: Entity
    {
        public int? Status { get; set; }
        public bool? IsDelete { get; set; }
        public string Creator { get; set; }

        public DateTime? CreateTime { get; set; }


        public string Updator { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}
