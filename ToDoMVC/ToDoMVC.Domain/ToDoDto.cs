using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMVC.Domain
{
    public class ToDoDto
    {
        public string Name { get; set; }
        public IList<ItemDto> Items { get; set; }
    }
}
