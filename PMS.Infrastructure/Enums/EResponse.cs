using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PMS.Infrastructure.Enums
{
    public enum EResponse
    {
        [Description("操作成功")]
        Ok = 200,

        [Description("未找到")]
        NotFound = 404,

        [Description("参数错误")]
        Erro = 500
    }
}
