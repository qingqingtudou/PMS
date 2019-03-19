using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Repository.Core
{
    /// <summary>
    /// 标准实体基类  包含数据状态、是否删除、创建人、创建时间
    /// </summary>
    public abstract class OperatEntity:Entity
    {
        /// <summary>
        /// 数据状态  
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }

        public string Creator { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
