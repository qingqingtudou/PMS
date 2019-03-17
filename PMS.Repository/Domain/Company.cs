using PMS.Repository.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Repository.Domain
{
    public partial class Company: StandardEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
