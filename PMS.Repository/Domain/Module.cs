using PMS.Repository.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMS.Repository.Domain
{
    /// <summary>
	/// 功能模块表
	/// </summary>
    [Table("Module")]
    public class Module: TreeEntity
    {
        /// <summary>
        /// 主页面URL
        /// </summary>
        [Description("主页面URL")]
        public string Url { get; set; }
        /// <summary>
        /// 热键
        /// </summary>
        [Description("热键")]
        public string HotKey { get; set; }
        /// <summary>
        /// 是否叶子节点
        /// </summary>
        [Description("是否叶子节点")]
        public bool IsLeaf { get; set; }
        /// <summary>
        /// 是否自动展开
        /// </summary>
        [Description("是否自动展开")]
        public bool IsAutoExpand { get; set; }
        /// <summary>
        /// 节点图标文件名称
        /// </summary>
        [Description("节点图标文件名称")]
        public string IconName { get; set; }

        /// <summary>
        /// 矢量图标
        /// </summary>
        [Description("矢量图标")]
        public string Vector { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        [Description("排序号")]
        public int SortNo { get; set; }

        /// <summary>
        /// 模块标识
        /// </summary>
        [Description("模块标识")]
        public string Code { get; set; }

        public virtual ICollection<RoleModule> RoleModules { get; set; }
    }
}
