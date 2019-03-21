using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Infrastructure
{
    public class TreeItem<T>
    {
        public T Item { get; set; }
        public IEnumerable<TreeItem<T>> Children { get; set; }
    }

    public class TreeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TreeModel> Children { get; set; }
        public int Pid { get; set; }
    }
}
