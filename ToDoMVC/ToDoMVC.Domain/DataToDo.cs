using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMVC.Domain
{
    public class DataToDo
    {
        public string Name { get; set; }
        public IList<DataItem> Items { get; set; }
    }
}
