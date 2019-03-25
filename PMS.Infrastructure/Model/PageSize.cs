using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Infrastructure.Model
{
    public class PageSize
    {
        public int page { get; set; }
        public int limit { get; set; }

        public string key { get; set; }

        public PageSize()
        {
            page = 1;
            limit = 10;
        }
    }
}
