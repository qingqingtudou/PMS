using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Infrastructure.Model
{
    public class QueryUserReq:PageSize
    {
        public string fullpath { get; set; }

        public int orgId { get; set; }
    }
}
