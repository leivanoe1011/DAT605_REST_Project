using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMVC.Domain
{
    public class ToDo
    {
        public string Name { get; set; }
        public IList<Item> Items { get; set; }
    }
}
