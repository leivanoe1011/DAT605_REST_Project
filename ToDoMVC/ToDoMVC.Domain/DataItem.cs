using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMVC.Domain
{

    /// Responsibilities:
    /// Data Object responsible to get and set Database values.
    
    public class DataItem
    {
        public string Name { get; set; }
        public string ToDoName { get; set; }
        //public virtual DataToDo ToDo { get; set; }
    }
}
