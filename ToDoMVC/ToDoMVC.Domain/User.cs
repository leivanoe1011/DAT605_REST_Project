using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMVC.Domain
{
    public class User
    {
        public string Name { get; set; }
        public IList<ToDo> ToDos { get; set; }
    }
}
