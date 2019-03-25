using PMS.Infrastructure.Model;
using PMS.Infrastructure.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Infrastructure.Response
{
    public class OperatePageResult
    {
        public int code { get; set; }

        public string msg { get; set; }

        /// <summary>
        /// 总记录条数
        /// </summary>
        public int count;

        /// <summary>
        ///  返回的列表头信息
        /// </summary>
        public List<KeyDescription> columnHeaders;

        /// <summary>
        /// 数据内容
        /// </summary>
        public dynamic data;

        public OperatePageResult()
        {
            code = 200;
            msg = "加载成功";
            columnHeaders = new List<KeyDescription>();
        }
    }
}
