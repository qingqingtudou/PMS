using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Infrastructure.Response
{
    public class OrgView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullPath { get; set; }
        public string FullPathText { get; set; }
        public int? Pid { get; set; }
        public string ParentName { get; set; }
        public int? Sort { get; set; }
    }
}
