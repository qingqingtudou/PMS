using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Repository.Core
{
    /// <summary>
    /// 顶级基类，只有Id
    /// </summary>
    public abstract class Entity
    {
        public int Id { get; set; }
    }
}
