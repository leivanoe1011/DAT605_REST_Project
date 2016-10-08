using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMVC.Contracts;
using ToDoMVC.Domain;
using ToDoMVC.Persistence;

namespace ToDoMVC.Business
{
    public class ItemDataMapper : IDataMapper<Item, DataItem>
    {
        public Item MapToDto(DataItem obj)
        {
            var item = new Item {Name = obj.Name};

            return item;
        }

        public DataItem MapToObject(Item obj)
        {
            var item = new DataItem {Name = obj.Name};

            return item;
        }
    }
}
