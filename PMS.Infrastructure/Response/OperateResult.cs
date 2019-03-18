using PMS.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Infrastructure.Response
{
    public class OperateResult
    {
        /// <summary>
        /// 操作消息【当Status不为 200时，显示详细的错误信息】
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 操作状态码，200为正常
        /// </summary>
        public int Code { get; set; }

        public OperateResult()
        {
            Code = (int)EResponse.Ok;
            Message = "操作成功";
        }
    }

    /// <summary>
    /// 通用返回泛型基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OperateResult<T> : OperateResult
    {
        /// <summary>
        /// 回传的结果
        /// </summary>
        public T Payload { get; set; }
    }
}
